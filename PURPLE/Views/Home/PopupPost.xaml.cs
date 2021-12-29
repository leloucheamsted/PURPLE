using Rg.Plugins.Popup.Extensions;
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
    public partial class PopupPost : PopupPage
    {
        public PopupPost()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
          await  App.Current.MainPage.Navigation.PopPopupAsync();
        }

        /*
          /*------- fonction de changement d'etat de la home page
          private async Task homeChange(Grid home, double opa, Color color, bool isenable)
          {
              home.Opacity = opa;
              home.BackgroundColor = color;
              BtnPlusOnglet.IsEnabled = isenable;
          }
          private void BtnPlusOnglet_AnimationCompleted(object sender, EventArgs e)
          {
              // si le popup est ferme
              Device.InvokeOnMainThreadAsync(async () =>
              {
                  await Task.WhenAll(
                  PopupPost.TranslateTo(0, 0, 200),
                 _ = homeChange(home_page, 0.4, Color.Black, false)

                  );
              });

              ispop = true; // signaler pour fermer
          }
          private void closeBtnPopup_AnimationCompleted(object sender, EventArgs e)
          {
              Device.InvokeOnMainThreadAsync(async () =>
              {
                  await Task.WhenAll(
                      _ = homeChange(home_page, 1, Color.White, true),
                      PopupPost.TranslateTo(0, 350, 200)

                      );
              });
              ispop = false; // active pour signaler qu'il est ouvert
          }

          var PopPost = new PostPage();
          App.Current.MainPage.Navigation.PushPopupAsync(PopPost,true);


           App.Current.MainPage.Navigation.PopPopupAsync(true);

          */
    }
}