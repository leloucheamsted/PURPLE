using PURPLE.Interface;
using PURPLE.Views.Home.AnimationListView;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.ListView.XForms;
using Syncfusion.GridCommon.ScrollAxis;
using Syncfusion.ListView.XForms.Control.Helpers;
using Syncfusion.XForms.EffectsView;
using PURPLE.Views.ACCEUILVIEW;

namespace PURPLE.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AcceuilPage : ContentPage
    {
        int indexPosition = 0;
        private uint animationLength = 250;
        bool ispop = false;
        VisualContainer visualContainer;
        bool isAlertShown = false;
        public AcceuilPage()
        {
            InitializeComponent();

            #region ListView event
            
            this.listview.ItemGenerator = new ItemGeneratorExt(this.listview);
          //  visualContainer = listview.GetVisualContainer();
           // visualContainer.ScrollRows.Changed += ScrollRows_Changed;
            
            //listview.ScrollStateChanged += ListView_ScrollStateChanged;
            #endregion

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

        private async void  SfEffectsView_TouchUp(object sender, EventArgs e)
        {
            
            var obj = ((SfEffectsView)sender).BindingContext as PostInfo;
            var readMoreContentPage = new VoirPlusPage(obj);
           await App.Current.MainPage.Navigation.PushAsync(readMoreContentPage);
        }

        #region Vue
        //Fonction de pagination entre les vue
        private async Task NavEvent()
        {
            // Appel la vue PURPLE
            if (indexPosition == 0)
            {
                Device.InvokeOnMainThreadAsync(async () => {
                    await Task.WhenAll(
                            Group_view.TranslateTo(600, 0, animationLength),
                            Purple_view.TranslateTo(0, 0, animationLength),
                            Acceuill_view.TranslateTo(600, 0, animationLength),
                            Chat_view.TranslateTo(600, 0, animationLength)
                        );
                });
            }
            else if (indexPosition == 1) // Appel la vue Acceuill
            {
                Device.InvokeOnMainThreadAsync(async () => {
                    await Task.WhenAll(
                            Group_view.TranslateTo(600, 0, animationLength),
                            Purple_view.TranslateTo(600, 0, animationLength),
                            Acceuill_view.TranslateTo(0, 0, animationLength),
                            Chat_view.TranslateTo(600, 0, animationLength)
                        );
                });
            }
            // Appel la vue Chat
            else if (indexPosition == 2)
            {
                Device.InvokeOnMainThreadAsync(async () => {
                    await Task.WhenAll(
                            Group_view.TranslateTo(600, 0, animationLength),
                            Purple_view.TranslateTo(600, 0, animationLength),
                            Acceuill_view.TranslateTo(600, 0, animationLength),
                            Chat_view.TranslateTo(0, 0, animationLength)
                        );
                });
            }
            // Appel la vue Group
            else if (indexPosition == 3)
            {
                Device.InvokeOnMainThreadAsync(async () => {
                    await Task.WhenAll(
                            Group_view.TranslateTo(0, 0, animationLength),
                            Purple_view.TranslateTo(600, 0, animationLength),
                            Acceuill_view.TranslateTo(600, 0, animationLength),
                            Chat_view.TranslateTo(600, 0, animationLength)
                        );
                });
            }


        }
        #region Navigation et evenement entre vue
        // Selexction de l'omglet purple
        private void PurpleOnglet_AnimationCompleted(object sender, EventArgs e)
        {
            // si l'onglet n'etait pas selctionner
            if(PurpleOnglet.BackgroundColor != Color.FromHex("#43A3DB"))
            {
                indexPosition=0;
                // Selectionner purple
                PurpleOnglet.BackgroundColor = Color.FromHex("#43A3DB");
                PurpleIcone.TextColor = Color.White;
                PurpleText.TextColor=Color.White;

                // deselectionner tout les autres
                //Acceuill
                AcceuilOnglet.BackgroundColor = Color.Transparent;
                AcceuilText.TextColor = Color.FromHex("#000000");
                AcceuilIcone.TextColor = Color.FromHex("#000000");

                //Chat
                ChatOnglet.BackgroundColor = Color.Transparent;
                ChatText.TextColor = Color.FromHex("#000000");
                ChatIcone.TextColor = Color.FromHex("#000000");

                //group
                GroupOnglet.BackgroundColor = Color.Transparent;
                GroupIcone.TextColor = Color.FromHex("#000000");
                GroupText.TextColor = Color.FromHex("#000000");
                Device.InvokeOnMainThreadAsync(async () =>
                {
                    await Task.WhenAll(
                        Group_view.TranslateTo(600, 0, animationLength),
                        Purple_view.TranslateTo(0, 0, animationLength),
                        Acceuill_view.TranslateTo(600, 0, animationLength),
                        Chat_view.TranslateTo(600, 0, animationLength)

                        );
                });
            }
           
        }

        private void AcceuilOnglet_AnimationCompleted(object sender, EventArgs e)
        {
            indexPosition = 1;
            // si l'onglet n'etait pas selctionner
            if (AcceuilOnglet.BackgroundColor != Color.FromHex("#43A3DB"))
            {
                // Selectionner acceuill
                AcceuilOnglet.BackgroundColor = Color.FromHex("#43A3DB");
                AcceuilIcone.TextColor = Color.White;
                AcceuilText.TextColor = Color.White;

                // deselectionner tout les autres
                //purple
                PurpleOnglet.BackgroundColor = Color.Transparent;
                PurpleIcone.TextColor = Color.FromHex("#000000");
                PurpleText.TextColor = Color.FromHex("#000000");

                //Chat
                ChatOnglet.BackgroundColor = Color.Transparent;
                ChatText.TextColor = Color.FromHex("#000000");
                ChatIcone.TextColor = Color.FromHex("#000000");

                //group
                GroupOnglet.BackgroundColor = Color.Transparent;
                GroupIcone.TextColor = Color.FromHex("#000000");
                GroupText.TextColor = Color.FromHex("#000000");

                Device.InvokeOnMainThreadAsync(async () =>
                {
                    await Task.WhenAll(
                        Group_view.TranslateTo(600, 0, animationLength),
                        Purple_view.TranslateTo(600, 0, animationLength),
                        Acceuill_view.TranslateTo(0, 0, animationLength),
                        Chat_view.TranslateTo(600, 0, animationLength)

                        );
                });
            }
        }


       
        private void ChatOnglet_AnimationCompleted(object sender, EventArgs e)
        {
            indexPosition = 2;
            // si l'onglet n'etait pas selctionner
            if (ChatOnglet.BackgroundColor != Color.FromHex("#43A3DB"))
            {
                // Selectionner chat
                ChatOnglet.BackgroundColor = Color.FromHex("#43A3DB");
                ChatIcone.TextColor = Color.White;
                ChatText.TextColor = Color.White;

                // deselectionner tout les autres
                //purple
                PurpleOnglet.BackgroundColor = Color.Transparent;
                PurpleIcone.TextColor = Color.FromHex("#000000");
                PurpleText.TextColor = Color.FromHex("#000000");

                //acceuill
                AcceuilOnglet.BackgroundColor = Color.Transparent;
                AcceuilText.TextColor = Color.FromHex("#000000");
                AcceuilIcone.TextColor = Color.FromHex("#000000");

                //group
                GroupOnglet.BackgroundColor = Color.Transparent;
                GroupIcone.TextColor = Color.FromHex("#000000");
                GroupText.TextColor = Color.FromHex("#000000");

                Device.InvokeOnMainThreadAsync(async () =>
                {
                    await Task.WhenAll(
                        Group_view.TranslateTo(600, 0, animationLength),
                        Purple_view.TranslateTo(600, 0, animationLength),
                        Acceuill_view.TranslateTo(600, 0, animationLength),
                        Chat_view.TranslateTo(0, 0, animationLength)

                        );
                });
            }
        }

        private void GroupOnglet_AnimationCompleted(object sender, EventArgs e)
        {
            indexPosition = 3;
            // si l'onglet n'etait pas selctionner
            if (GroupOnglet.BackgroundColor != Color.FromHex("#43A3DB"))
            {
                // Selectionner group
                GroupOnglet.BackgroundColor = Color.FromHex("#43A3DB");
                GroupIcone.TextColor = Color.White;
                GroupText.TextColor = Color.White;

                // deselectionner tout les autres
                //purple
                PurpleOnglet.BackgroundColor = Color.Transparent;
                PurpleIcone.TextColor = Color.FromHex("#000000");
                PurpleText.TextColor = Color.FromHex("#000000");

                //Chat
                ChatOnglet.BackgroundColor = Color.Transparent;
                ChatText.TextColor = Color.FromHex("#000000");
                ChatIcone.TextColor = Color.FromHex("#000000");

                //acceuil
                AcceuilOnglet.BackgroundColor = Color.Transparent;
                AcceuilIcone.TextColor = Color.FromHex("#000000");
                AcceuilText.TextColor = Color.FromHex("#000000");
                Device.InvokeOnMainThreadAsync(async () =>
                {
                    await Task.WhenAll(
                        Group_view.TranslateTo(0,0, animationLength),
                        Purple_view.TranslateTo(600, 0, animationLength),
                        Acceuill_view.TranslateTo(600, 0, animationLength),
                        Chat_view.TranslateTo(600, 0, animationLength)
                       
                        );
                });
               
            }
        }
        #endregion

        private async void BtnPlusOnglet_AnimationCompleted(object sender, EventArgs e)
        {
            var readMoreContentPage = new PopupPost();
          await  App.Current.MainPage.Navigation.PushPopupAsync(readMoreContentPage);
        }
        #endregion

        #region ListView

        // determiner si nous avons atteint la fin de la liste
        private void ScrollRows_Changed(object sender, ScrollChangedEventArgs e)
        {
            var lastIndex = visualContainer.ScrollRows.LastBodyVisibleLineIndex;
            /*
            //To include header if used
            var header = (ListView.HeaderTemplate != null && !listView.IsStickyHeader) ? 1 : 0;

            //To include footer if used
            var footer = (listView.FooterTemplate != null && !listView.IsStickyFooter) ? 1 : 0;
            var totalItems = listView.DataSource.DisplayItems.Count + header + footer;
            */
            var totalItems = listview.DataSource.DisplayItems.Count ;
            
            if ((lastIndex == totalItems - 1))
            {
                if (!isAlertShown)
                {
                    DisplayAlert("Alert", "End of list reached...", "Ok");
                    isAlertShown = true;
                }
            }
            else
                isAlertShown = false;
        }

        // determiner si la liste est en defilement ou pas
        private void ListView_ScrollStateChanged(object sender, ScrollStateChangedEventArgs e)
        {
            if (e.ScrollState == ScrollState.Idle)
            {
                DisplayAlert("ScrollState", "Scrolling has stopped", "OK");
            }
        }


        #endregion

        private async void Btn_hashtag_AnimationCompleted(object sender, EventArgs e)
        {
            var hastagsPage = new HastagsPage();
            await App.Current.MainPage.Navigation.PushAsync(hastagsPage);
        }
    }
}