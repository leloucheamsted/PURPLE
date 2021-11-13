using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Timers;
using Xamarin.Forms;
using PURPLE.Interface;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PURPLE.LoginSignUp.SignUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
    {

        public SignupPage()
        {
            InitializeComponent();
            var currentNavPage = (Application.Current.MainPage as NavigationPage);
            var statusBarStyleManager = DependencyService.Get<IStatusBarStyleManager>();
           
            
        }
         protected override void OnAppearing()
        { 
            base.OnAppearing();
            var currentNavPage = (Application.Current.MainPage as NavigationPage);
            var statusBarStyleManager = DependencyService.Get<IStatusBarStyleManager>();
            currentNavPage.BarBackgroundColor = Color.DarkCyan;
            statusBarStyleManager.SetDarkTheme();
           
        }

    }
}