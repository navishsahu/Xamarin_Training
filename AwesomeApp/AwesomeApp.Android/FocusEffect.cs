using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(AwesomeApp.Droid.FocusEffect), nameof(AwesomeApp.Droid.FocusEffect))]
namespace AwesomeApp.Droid
{
    public class FocusEffect : PlatformEffect
    {
        Android.Graphics.Color originalColor = new Android.Graphics.Color(0, 0, 0, 0);
        Android.Graphics.Color bgColor;

        protected override void OnAttached()
        {
            try
            {
                bgColor = Android.Graphics.Color.LightGreen;
                Control.SetBackgroundColor(bgColor);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot set property. Error: ", e.Message);
            }
        }

        protected override void OnDetached()
        {
            throw new NotImplementedException();
        }

        protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            try
            {
                if (args.PropertyName == "IsFocused")
                {
                    if (((Android.Graphics.Drawables.ColorDrawable)Control.Background).Color == bgColor)
                    {
                        Control.SetBackgroundColor(originalColor);
                    }
                    else
                    {
                        Control.SetBackgroundColor(bgColor);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot set property. Error: ", e.Message);
            }
        }
    }
}