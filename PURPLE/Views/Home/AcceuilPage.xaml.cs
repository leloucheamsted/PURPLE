using PURPLE.Interface;
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
    public partial class AcceuilPage : ContentPage
    {
        int indexPosition = 0;
        public AcceuilPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var currentNavPage = (Application.Current.MainPage as NavigationPage);
            var statusBarStyleManager = DependencyService.Get<IStatusBarStyleManager>();
            currentNavPage.BarBackgroundColor = Color.DarkCyan;
            statusBarStyleManager.SetLightTheme("#DCE8F6");
            statusBarStyleManager.SetNavigationBarColor("#DCE8F6");
            await NavEvent();

        }

        //Fonction de pagination entre les vue
        private async Task NavEvent()
        {
            // Appel la vue PURPLE
            if (indexPosition == 0)
            {
                Device.InvokeOnMainThreadAsync(async () => {
                    await Task.WhenAll(
                            Group_view.TranslateTo(600, 0, 400),
                            Purple_view.TranslateTo(0, 0, 400),
                            Acceuill_view.TranslateTo(600, 0, 400),
                            Chat_view.TranslateTo(600, 0, 400)
                        );
                });
            }
            else if (indexPosition == 1) // Appel la vue Acceuill
            {
                Device.InvokeOnMainThreadAsync(async () => {
                    await Task.WhenAll(
                            Group_view.TranslateTo(600, 0, 400),
                            Purple_view.TranslateTo(600, 0, 400),
                            Acceuill_view.TranslateTo(0, 0, 400),
                            Chat_view.TranslateTo(600, 0, 400)
                        );
                });
            }
            // Appel la vue Chat
            else if (indexPosition == 2)
            {
                Device.InvokeOnMainThreadAsync(async () => {
                    await Task.WhenAll(
                            Group_view.TranslateTo(600, 0, 400),
                            Purple_view.TranslateTo(600, 0, 400),
                            Acceuill_view.TranslateTo(600, 0, 400),
                            Chat_view.TranslateTo(0, 0, 400)
                        );
                });
            }
            // Appel la vue Group
            else if (indexPosition == 3)
            {
                Device.InvokeOnMainThreadAsync(async () => {
                    await Task.WhenAll(
                            Group_view.TranslateTo(0, 0, 400),
                            Purple_view.TranslateTo(600, 0, 400),
                            Acceuill_view.TranslateTo(600, 0, 400),
                            Chat_view.TranslateTo(600, 0, 400)
                        );
                });
            }


        }
        #region Navigation et evenement entre vue
        // Selexction de l'omglet purple
        private void PurpleOnglet_AnimationCompleted(object sender, EventArgs e)
        {
            // si l'onglet n'etait pas selctionner
            if(PurpleOnglet.BackgroundColor != Color.FromHex("#2673D1"))
            {
                indexPosition=0;
                // Selectionner purple
                PurpleOnglet.BackgroundColor = Color.FromHex("#2673D1");
                PurpleIcone.TextColor = Color.White;
                PurpleText.TextColor=Color.White;

                // deselectionner tout les autres
                //Acceuill
                AcceuilOnglet.BackgroundColor = Color.Transparent;
                AcceuilText.TextColor = Color.FromHex("#0F2D52");
                AcceuilIcone.TextColor = Color.FromHex("#0F2D52");

                //Chat
                ChatOnglet.BackgroundColor = Color.Transparent;
                ChatText.TextColor = Color.FromHex("#0F2D52");
                ChatIcone.TextColor = Color.FromHex("#0F2D52");

                //group
                GroupOnglet.BackgroundColor = Color.Transparent;
                GroupIcone.TextColor = Color.FromHex("#0F2D52");
                GroupText.TextColor = Color.FromHex("#0F2D52");
                Device.InvokeOnMainThreadAsync(async () =>
                {
                    await Task.WhenAll(
                        Group_view.TranslateTo(600, 0, 400),
                        Purple_view.TranslateTo(0, 0, 400),
                        Acceuill_view.TranslateTo(600, 0, 400),
                        Chat_view.TranslateTo(600, 0, 400)

                        );
                });
            }
           
        }

        private void AcceuilOnglet_AnimationCompleted(object sender, EventArgs e)
        {
            indexPosition = 1;
            // si l'onglet n'etait pas selctionner
            if (AcceuilOnglet.BackgroundColor != Color.FromHex("#2673D1"))
            {
                // Selectionner acceuill
                AcceuilOnglet.BackgroundColor = Color.FromHex("#2673D1");
                AcceuilIcone.TextColor = Color.White;
                AcceuilText.TextColor = Color.White;

                // deselectionner tout les autres
                //purple
                PurpleOnglet.BackgroundColor = Color.Transparent;
                PurpleIcone.TextColor = Color.FromHex("#0F2D52");
                PurpleText.TextColor = Color.FromHex("#0F2D52");

                //Chat
                ChatOnglet.BackgroundColor = Color.Transparent;
                ChatText.TextColor = Color.FromHex("#0F2D52");
                ChatIcone.TextColor = Color.FromHex("#0F2D52");

                //group
                GroupOnglet.BackgroundColor = Color.Transparent;
                GroupIcone.TextColor = Color.FromHex("#0F2D52");
                GroupText.TextColor = Color.FromHex("#0F2D52");

                Device.InvokeOnMainThreadAsync(async () =>
                {
                    await Task.WhenAll(
                        Group_view.TranslateTo(600, 0, 400),
                        Purple_view.TranslateTo(600, 0, 400),
                        Acceuill_view.TranslateTo(0, 0, 400),
                        Chat_view.TranslateTo(600, 0, 400)

                        );
                });
            }
        }


       
        private void ChatOnglet_AnimationCompleted(object sender, EventArgs e)
        {
            indexPosition = 2;
            // si l'onglet n'etait pas selctionner
            if (ChatOnglet.BackgroundColor != Color.FromHex("#2673D1"))
            {
                // Selectionner chat
                ChatOnglet.BackgroundColor = Color.FromHex("#2673D1");
                ChatIcone.TextColor = Color.White;
                ChatText.TextColor = Color.White;

                // deselectionner tout les autres
                //purple
                PurpleOnglet.BackgroundColor = Color.Transparent;
                PurpleIcone.TextColor = Color.FromHex("#0F2D52");
                PurpleText.TextColor = Color.FromHex("#0F2D52");

                //acceuill
                AcceuilOnglet.BackgroundColor = Color.Transparent;
                AcceuilText.TextColor = Color.FromHex("#0F2D52");
                AcceuilIcone.TextColor = Color.FromHex("#0F2D52");

                //group
                GroupOnglet.BackgroundColor = Color.Transparent;
                GroupIcone.TextColor = Color.FromHex("#0F2D52");
                GroupText.TextColor = Color.FromHex("#0F2D52");

                Device.InvokeOnMainThreadAsync(async () =>
                {
                    await Task.WhenAll(
                        Group_view.TranslateTo(600, 0, 400),
                        Purple_view.TranslateTo(600, 0, 400),
                        Acceuill_view.TranslateTo(600, 0, 400),
                        Chat_view.TranslateTo(0, 0, 400)

                        );
                });
            }
        }

        private void GroupOnglet_AnimationCompleted(object sender, EventArgs e)
        {
            indexPosition = 3;
            // si l'onglet n'etait pas selctionner
            if (GroupOnglet.BackgroundColor != Color.FromHex("#2673D1"))
            {
                // Selectionner group
                GroupOnglet.BackgroundColor = Color.FromHex("#2673D1");
                GroupIcone.TextColor = Color.White;
                GroupText.TextColor = Color.White;

                // deselectionner tout les autres
                //purple
                PurpleOnglet.BackgroundColor = Color.Transparent;
                PurpleIcone.TextColor = Color.FromHex("#0F2D52");
                PurpleText.TextColor = Color.FromHex("#0F2D52");

                //Chat
                ChatOnglet.BackgroundColor = Color.Transparent;
                ChatText.TextColor = Color.FromHex("#0F2D52");
                ChatIcone.TextColor = Color.FromHex("#0F2D52");

                //acceuil
                AcceuilOnglet.BackgroundColor = Color.Transparent;
                AcceuilIcone.TextColor = Color.FromHex("#0F2D52");
                AcceuilText.TextColor = Color.FromHex("#0F2D52");
                Device.InvokeOnMainThreadAsync(async () =>
                {
                    await Task.WhenAll(
                        Group_view.TranslateTo(0,0,400),
                        Purple_view.TranslateTo(600, 0, 400),
                        Acceuill_view.TranslateTo(600, 0, 400),
                        Chat_view.TranslateTo(600, 0, 400)
                       
                        );
                });
               
            }
        }
        #endregion
    }
}