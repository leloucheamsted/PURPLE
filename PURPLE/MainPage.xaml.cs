using System;
using System.Timers;
using Xamarin.Forms;
using PURPLE.Interface;

namespace PURPLE
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
            {
                InitializeComponent();
            var currentNavPage = (Application.Current.MainPage as NavigationPage);
            var statusBarStyleManager = DependencyService.Get<IStatusBarStyleManager>();
            currentNavPage.BarBackgroundColor = Color.LightGreen;
                statusBarStyleManager.SetLightTheme();
        }

       
    }
    
}
