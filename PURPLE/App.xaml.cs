using PURPLE.LoginSignUp.Login;
using PURPLE.LoginSignUp.SignUp;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: ExportFont("Font Awesome 6 Free-Solid-900.otf", Alias = "fa")]
namespace PURPLE
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new SignupPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
