using Xamarin.Forms;
using PURPLE.Interface;
using Xamarin.Forms.Xaml;

namespace PURPLE.LoginSignUp.SignUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
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

    }
}