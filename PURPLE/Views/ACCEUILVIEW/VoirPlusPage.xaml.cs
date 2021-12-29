using PURPLE.Interface;
using PURPLE.Models.AcceuilModel;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PURPLE.Views.ACCEUILVIEW
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VoirPlusPage : ContentPage
    {
        public  VoirPlusPage(PostInfo obj)
        {
            InitializeComponent();
            BindingContext = obj;
            
            
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

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var obj = ((StackLayout)sender).BindingContext as commentaire;
            string nom = obj.NomUtilisateur;
            Entrer_du_commentaire.Text = "@"+ nom + " ";
            Entrer_du_commentaire.Focus();

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            var obj = ((Label)sender).BindingContext as reponse;
            string nom = obj.NomUtilisateur;
            Entrer_du_commentaire.Text = "@" + nom + " ";
            Entrer_du_commentaire.Focus();
        }
    }
}