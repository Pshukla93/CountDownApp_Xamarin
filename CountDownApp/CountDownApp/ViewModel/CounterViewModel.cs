using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using CountDownApp.Model;
using Xamarin.Forms;

namespace CountDownApp.ViewModel
{
	public class CounterViewModel: INotifyPropertyChanged
    {
        int angles = 0; int anglem = 0; int angleh = 0; int angled = 0;
        Frame frs,frm,frh,frd = null;
		public CounterViewModel(Frame frameh,Frame framed, Frame framem, Frame frames)
		{
            frh = frameh;
            frd = framed;
            frm = framem;
            frs = frames;
            Days = "08";
            Hours = "23";
            Minutes = "55";
            Seconds = "41";
            Setup();
        }
        private void Setup()
        {
            

            Event _event = new Event();
            _event.Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(08, 23, 55, 41).Ticks);

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {



                
                var timespan = _event.Date - DateTime.Now;
                _event.Timespan = timespan;
                //Device.BeginInvokeOnMainThread(async () => {
                //    await fr.RotateXTo(180);
                //});
                //fr.RotateXTo(360, easing: Easing.Linear);
                Days = timespan.Days.ToString("00");
                Hours = timespan.Hours.ToString("00");
                Minutes = timespan.Minutes.ToString("00");
                Seconds = timespan.Seconds.ToString("00");
                
                //frame.RotateYTo(0);
                //frame.RotateYTo(199 * 360);

                return true;
            });
        }
        private string _day;
        public string Days
        {
            get
            {
                return _day;
            }
            set
            {
                _day = value;
                OnPropertyChanged();
               
            }
        }
        private string _hours;
        public string Hours
        {
            get
            {
                return _hours;
            }
            set
            {
                if (value == "00")
                {
                    angled += 90;
                    frd.RotateXTo(angled, easing: Easing.Linear);
                }
                _hours = value;
                OnPropertyChanged();
               
            }
        }

        private string _minutes;
        public string Minutes
        {
            get
            {
                return _minutes;
            }
            set
            {
                if (value == "00")
                {
                    angleh += 90;
                    frh.RotateXTo(angleh, easing: Easing.Linear);
                }
                _minutes = value;
                OnPropertyChanged();
            }
        }
        private string _seconds;
        public string Seconds
        {
            get
            {
                return _seconds;
            }
            set
            {
                if (value == "00")
                {
                    anglem += 180;
                    frm.RotateXTo(anglem, easing: Easing.Linear);
                }
                _seconds = value;

                OnPropertyChanged();
                angles += 180;
                frs.RotateXTo(angles, easing: Easing.Linear);


            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string message = null, string propertyName = null)
        {
            try
            {

                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(message ?? propertyName));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception found at  :: " + new StackTrace().GetFrame(0).GetMethod() + "", ex.Message);
            }
        }
    }
}

