using Android.OS;
using Android.Views;
using Plugin.CurrentActivity;
using PURPLE.Interface;
using Xamarin.Forms;
using PURPLE.Droid.Services;
using Xamarin.Essentials;
using Xamarin.Forms.Platform.Android;
[assembly:Dependency(typeof(StatusBarStyleManager))]
namespace PURPLE.Droid.Services
{
    public class StatusBarStyleManager : IStatusBarStyleManager
    {
        [System.Obsolete]
        public void SetDarkTheme(string textcolor)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Color color = Color.FromHex(textcolor);
                    var currentWindow = GetCurrentWindow();
                    currentWindow.DecorView.SystemUiVisibility = 0;
                    currentWindow.SetStatusBarColor(color.ToAndroid());
                   
                });
            }
        }

        [System.Obsolete]
        public void SetLightTheme(string textcolor)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Color color = Color.FromHex(textcolor);
                    var currentWindow = GetCurrentWindow();
                    currentWindow.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LightStatusBar;
                    currentWindow.SetStatusBarColor(color.ToAndroid());
                    
                });
            }
        }

        Window GetCurrentWindow()
        {
            var window = CrossCurrentActivity.Current.Activity.Window;

            // clear FLAG_TRANSLUCENT_STATUS flag:
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);

            // add FLAG_DRAWS_SYSTEM_BAR_BACKGROUNDS flag to the window
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            return window;
        }

        [System.Obsolete]
        public void SetNavigationBarColor(string hexColor)
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.M)
            {
                return;
            }

            Color color = Color.FromHex(hexColor);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                var currentWindow = GetCurrentWindow();
                currentWindow.SetNavigationBarColor(color.ToAndroid());
                currentWindow.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LightStatusBar;
            });
        }

      
       
    }
}
