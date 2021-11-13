using UIKit;
using Xamarin.Forms;
using PURPLE.iOS.Services;
using PURPLE.Interface;

[assembly: Dependency(typeof(StatusBarStyleManager))]
namespace PURPLE.iOS.Services
{
    public class StatusBarStyleManager : IStatusBarStyleManager
    {
        public void SetDarkTheme(string textcolor)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);
                GetCurrentViewController().SetNeedsStatusBarAppearanceUpdate();
            });
        }

        public void SetLightTheme(string textcolor)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.Default, false);
                GetCurrentViewController().SetNeedsStatusBarAppearanceUpdate();
            });
        }

        public void SetNavigationBarColor(string hexColor)
        {
            throw new System.NotImplementedException();
        }

        UIViewController GetCurrentViewController()
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            while (vc.PresentedViewController != null)
                vc = vc.PresentedViewController;
            return vc;
        }
    }
}