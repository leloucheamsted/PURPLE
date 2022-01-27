using Xamarin.Forms;
using PURPLE.Interface;
using Xamarin.Forms.Xaml;
using PURPLE.LoginSignUp.Login;
using FormsControls.Base;
using PURPLE.Views.LoginSignUp.SignUp;
using PURPLE.Views.Home;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Threading.Tasks;

namespace PURPLE.LoginSignUp.SignUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : AnimationPage
    {
        
        public SignupPage()
        {
            InitializeComponent();
           
        }
         protected override void OnAppearing()
        { 
            base.OnAppearing();
            var currentNavPage = (Application.Current.MainPage as NavigationPage);
            var statusBarStyleManager = DependencyService.Get<IStatusBarStyleManager>();
            currentNavPage.BarBackgroundColor = Color.DarkCyan;
            statusBarStyleManager.SetLightTheme("#DCE8F6");
            statusBarStyleManager.SetNavigationBarColor("#DCE8F6");
           
        }

        private async void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            var formulaire = new LoginPage();
            await App.Current.MainPage.Navigation.PushAsync(formulaire);
        }

        private async void Btn_Register_Clicked(object sender, System.EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushPopupAsync(new PostPage());
           
            Device.BeginInvokeOnMainThread(async () => {
              
                await App.Current.MainPage.Navigation.PushAsync(new FormSignUpPage());
            });
            await Task.Delay(1000);
           await Navigation.PopPopupAsync();
            
        }
        
    
       
    }
}