using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountDownApp.Model;
using CountDownApp.ViewModel;
using Xamarin.Forms;

namespace CountDownApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new CounterViewModel(frameh,framed,framem,frames);
        }
    }
}

