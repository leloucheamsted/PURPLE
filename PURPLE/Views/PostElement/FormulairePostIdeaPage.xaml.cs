using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PURPLE.Views.PostElement
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormulairePostIdeaPage : ContentPage
    {
        uint animationLength = 300;
        public FormulairePostIdeaPage()
        {
            InitializeComponent();
            closeVideo(false);

        }

        #region hashtags
        /// <summary>
        ///  Masquer la liste de hashat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            closeHashtagView();
        }

        private void closeHashtagView()
        {
            Device.InvokeOnMainThreadAsync(async () =>
            {

                await Task.WhenAll(
                   stacklist.TranslateTo(0,800, animationLength),
                   stacklist.FadeTo(0, animationLength)
                   );


            });
        }

        /// <summary>
        /// Ajout du hashtag a la zone dedition de texte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ajout_Hashtag(object sender, EventArgs e)
        {
            var hash = (Label)sender;
            description_entry.Text += hash.Text;
            description_entry.Focus();
            closeHashtagView();
        }


        /// <summary>
        ///  Clique sur le bouton d'qffiche de hashtags
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SfButton_Clicked(object sender, EventArgs e)
        {
            Device.InvokeOnMainThreadAsync(async () =>
            {

                await Task.WhenAll(
                    stacklist.TranslateTo(0, 0, animationLength),
                    stacklist.FadeTo(1, animationLength)
                   );


            });

        }
        #endregion

        #region Media element
        /// <summary>
        /// 
        /// Label video de fermerture de la vue de la video
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            closeVideo(false);
            mediaElement.Source = null;
        }

        private void TakeVideo(object sender,EventArgs e)
        {
            Device.InvokeOnMainThreadAsync(async () =>
            {
                await CrossMedia.Current.Initialize();
                //   flexMedia.Children.Clear();
                var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
                {

                });

                if (file == null)
                    return;

                closeVideo(true);

                mediaElement.Source = (file.Path);
                mediaElement.AutoPlay = false;
                mediaElement.Pause();

            });
        }
        /// <summary>
        /// Controle de lecture de la video
        /// </summary> 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            if (mediaElement.CurrentState == MediaElementState.Stopped ||
        mediaElement.CurrentState == MediaElementState.Paused)
            {
                mediaElement.Play();
            }
            else if (mediaElement.CurrentState == MediaElementState.Playing)
            {
                mediaElement.Pause();
            }
        }



        public void closeVideo(bool statut)
        {
            if (statut == false)
            {
                viewVideo.IsVisible = false;
                mediaElement.IsEnabled = false;
                closevideo.IsEnabled = false;
            }
            else
            {
                viewVideo.IsVisible = true;
                mediaElement.IsEnabled = true;
                closevideo.IsEnabled = true;
            }
        }
        #endregion
    }
}