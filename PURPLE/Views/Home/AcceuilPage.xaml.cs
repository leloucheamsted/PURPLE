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
            currentNavPage.BarBackgroundColor = Color.LightBlue;
            statusBarStyleManager.SetLightTheme("#ffffff");
            statusBarStyleManager.SetNavigationBarColor("#ffffff");
            ; 

        }

        private async void  SfEffectsView_TouchUp(object sender, EventArgs e)
        {
            
            var obj = ((SfEffectsView)sender).BindingContext as PostInfo;
            var readMoreContentPage = new VoirPlusPage(obj);
           await App.Current.MainPage.Navigation.PushAsync(readMoreContentPage);
        }

      

        #region ListView

        // determiner si nous avons atteint la fin de la liste
        private void ScrollRows_Changed(object sender, ScrollChangedEventArgs e)
        {
            var lastIndex = visualContainer.ScrollRows.LastBodyVisibleLineIndex;
         
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

        private async void Notification_Btn1_AnimationCompleted(object sender, EventArgs e)
        {
            var notificationPage = new NotificationPage();
            await App.Current.MainPage.Navigation.PushAsync(notificationPage);
        }
    }
}