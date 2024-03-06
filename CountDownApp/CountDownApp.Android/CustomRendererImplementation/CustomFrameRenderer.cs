using System;
using Android.Graphics.Drawables;
using AndroidX.ConstraintLayout.Core.Motion.Utils;
using CountDownApp.CustomRenderer;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using FrameRenderer = Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer;
using CountDownApp.Droid.CustomRendererImplementation;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace CountDownApp.Droid.CustomRendererImplementation
{
	public class CustomFrameRenderer : FrameRenderer
    {
        public CustomFrameRenderer(Context context)
            : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null && Control != null)
            {
                UpdateCornerRadius();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                base.OnElementPropertyChanged(sender, e);

                if (e.PropertyName == nameof(CustomFrame.CornerRadius) ||
                    e.PropertyName == nameof(CustomFrame))
                {
                    UpdateCornerRadius();
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        private void UpdateCornerRadius()
        {
            try
            {
                if (Control.Background is GradientDrawable backgroundGradient)
                {
                    var cornerRadius = (Element as CustomFrame)?.CornerRadius;
                    if (!cornerRadius.HasValue)
                    {
                        return;
                    }

                    var topLeftCorner = Context.ToPixels(cornerRadius.Value.TopLeft);
                    var topRightCorner = Context.ToPixels(cornerRadius.Value.TopRight);
                    var bottomLeftCorner = Context.ToPixels(cornerRadius.Value.BottomLeft);
                    var bottomRightCorner = Context.ToPixels(cornerRadius.Value.BottomRight);

                    var cornerRadii = new[]
                    {
                    topLeftCorner,
                    topLeftCorner,

                    topRightCorner,
                    topRightCorner,

                    bottomRightCorner,
                    bottomRightCorner,

                    bottomLeftCorner,
                        bottomLeftCorner,
                };

                    backgroundGradient.SetCornerRadii(cornerRadii);
                }

            }
            catch (Exception ex)
            {
                
            }
        }
    }
}

