using FormsControls.Base;
using Plugin.Media;
using Plugin.Media.Abstractions;
using PURPLE.Interface;
using PURPLE.Models.PostTypeModel;
using PURPLE.Views.Home;
using Syncfusion.XForms.Buttons;
using Syncfusion.XForms.EffectsView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Core;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PURPLE.Views.PostElement
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormulairePostReussitePage : ContentPage
    {
        private uint animationLength = 300;
        public FormulairePostReussitePage()
        {
            InitializeComponent();
           

        }

        protected  override void OnAppearing()
        {
            base.OnAppearing();
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
                   stacklist.TranslateTo(400, 0, animationLength),
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
            var hash =(Label) sender;
            desciprion_entry.Text += hash.Text;
            desciprion_entry.Focus();
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

        #region competences zone
        /// <summary>
        /// Evenement d'apparition de la liste des comeptences
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompetenceBtn_Clicked(object sender, EventArgs e)
        {
            Device.InvokeOnMainThreadAsync(async () =>
            {

                await Task.WhenAll(
                   Listcompetences.TranslateTo(0, 0, animationLength),
                   Listcompetences.FadeTo(1, animationLength)
                   );


            });



        }

        private void TapGestureRecognizer_Tapped_1(object sender,EventArgs e)
        {
            closeCompetenceView();
        }

        public void closeCompetenceView()
        {
            Device.InvokeOnMainThreadAsync(async () =>
            {

                await Task.WhenAll(
                    Listcompetences.TranslateTo(0, 800, animationLength),
                    Listcompetences.FadeTo(0, animationLength)
                   );


            });
        }

        /// <summary>
        /// CLiaue sur un element de la liste de competences 
        /// Ajout de cet element a note flexLayout de competences
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            var lab = (Label)sender;
            Label label = new Label() {
                Text = lab.Text,
            };
            string text = label.Text;

            #region sfview
            SfButton sfv = new SfButton()
            {
                Padding = new Thickness(5),
                Margin = new Thickness(5, 0, 0, 0),
                BackgroundColor = Color.White,
                BorderWidth = 1,
                BorderColor = Color.FromHex("#43A3DB"),
                CornerRadius = 20,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,


            };
            sfv.Clicked += (s, x) =>
            {
                var sf = (SfButton)s;

                flexLayoutCompetences.Children.Remove(sf);
            };
            #endregion


            // Added lABEL IN DFVIEW Listcompetences
             sfv.Content = label;
            flexLayoutCompetences.Children.Add(sfv);
            closeCompetenceView();

        }



        #endregion

        #region DateTime

        /// <summary>
        /// Selection de la data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void date_DateSelected(object sender, DateChangedEventArgs e)
        {

            TimePicker TimePicker = new TimePicker();
            var h = DateTime.Now.ToString("HH:mm");
            DateBtn.Text = date.Date.ToString("dd/MM/yyy");
            Debug.WriteLine(h);



        }
        #endregion

        #region Media element
        private async void CameraBtn_AnimationCompletedAsync(object sender, EventArgs e)
        {

            #region creation de la vue
            Grid g = new Grid()
            {
                HeightRequest = 130,
                Margin = new Thickness(5, 5),
                Padding = new Thickness(0),
            };


          //  flexMedia.Children.Add(g);
            Image img = new Image() { };
            Image icone = new Image()
            {
                Margin = new Thickness(-5),
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Start,
                Source = "remove.png",
                HeightRequest = 14,
                WidthRequest = 14
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, a) => {
                var ico = (Image)s;
                Grid grid = (Grid)ico.Parent;
             //   flexMedia.Children.Remove(grid);
            };
            icone.GestureRecognizers.Add(tapGestureRecognizer);
            #endregion

            await CrossMedia.Current.Initialize();


            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {

            });

            if (file == null)
                return;


            img.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
            g.Children.Add(img);
            g.Children.Add(icone);
        }

        private async void VideoBtn_AnimationCompleted(object sender, EventArgs e)
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

          
        }


        /// <summary>
        ///  Affiche du popup du chiox de picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SelectPhotoBtn_AnimationCompleted(object sender, EventArgs e)
        {

            // Cgoix du type de Selection gallerie
            string action = await DisplayActionSheet(null, null, null, "Selection photo", "Selection video");

            if (action == "Selection photo")
            {
                #region creation de la vue
                Grid g = new Grid()
                {
                    HeightRequest = 130,
                    Margin = new Thickness(5, 5),
                    Padding = new Thickness(0),
                };


                flexMedia.Children.Add(g);
                Image img = new Image() { };
                Image icone = new Image()
                {
                    Margin = new Thickness(-5),
                    HorizontalOptions = LayoutOptions.End,
                    VerticalOptions = LayoutOptions.Start,
                    Source = "remove.png",
                    HeightRequest = 14,
                    WidthRequest = 14
                };

                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, a) => {
                    var ico = (Image)s;
                    Grid grid = (Grid)ico.Parent;
                    flexMedia.Children.Remove(grid);
                };
                icone.GestureRecognizers.Add(tapGestureRecognizer);
                #endregion

                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                    return;
                }
                var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                });
                img.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
                g.Children.Add(img);
                g.Children.Add(icone);

            }
            else if (action == "Selection video")
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickVideoSupported)
                {
                    await DisplayAlert("Videos Not Supported", ":( Permission not granted to videos.", "OK");
                    return;
                }
                var file = await CrossMedia.Current.PickVideoAsync();
                flexMedia.Children.Clear();
                if (file == null)
                    return;

                closeVideo(true);

                mediaElement.Source = (file.Path);
                mediaElement.AutoPlay = false;
                mediaElement.Pause();

            }
            else
            {

            }

          
        }

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
