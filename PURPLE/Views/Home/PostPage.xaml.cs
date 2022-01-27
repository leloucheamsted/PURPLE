using FormsControls.Base;
using PURPLE.Interface;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PURPLE.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostPage : PopupPage
    {
        public PostPage()
        {
            InitializeComponent();
            
           

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var currentNavPage = (Application.Current.MainPage as NavigationPage);
            var statusBarStyleManager = DependencyService.Get<IStatusBarStyleManager>();
            currentNavPage.BarBackgroundColor = Color.DarkCyan;
            statusBarStyleManager.SetLightTheme("#ffffff");
            statusBarStyleManager.SetNavigationBarColor("#ffffff");


        }
    }
}