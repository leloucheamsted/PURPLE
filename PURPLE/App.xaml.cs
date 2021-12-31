using FormsControls.Base;
using PURPLE.LoginSignUp.Login;
using PURPLE.LoginSignUp.SignUp;
using PURPLE.TestVue;
using PURPLE.Views;
using PURPLE.Views.Home;
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
            Device.SetFlags(new string[] { "MediaElement_Experimental" });
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTU0OTI3QDMxMzkyZTM0MmUzMGNDSGpDV2VYZ0owcmVGWk9salcxb0FncFhhV1RaYythWHBnU045UE5rRFE9");
            InitializeComponent();
            MainPage = new AnimationNavigationPage(new TabbedNavPage());
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
