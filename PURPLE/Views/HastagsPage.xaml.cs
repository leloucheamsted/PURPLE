using FormsControls.Base;
using PURPLE.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PURPLE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HastagsPage : AnimationPage
    {
        public HastagsPage()
        {
            InitializeComponent();
        }
        protected  override void OnAppearing()
        {
            base.OnAppearing();
            var currentNavPage = (Application.Current.MainPage as NavigationPage);
            var statusBarStyleManager = DependencyService.Get<IStatusBarStyleManager>();
            currentNavPage.BarBackgroundColor = Color.DarkCyan;
            statusBarStyleManager.SetLightTheme("#ffffff");
            statusBarStyleManager.SetNavigationBarColor("#ffffff");
           

        }

        private async void BackButton_AnimationCompleted(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}