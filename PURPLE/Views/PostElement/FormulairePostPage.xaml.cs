using FormsControls.Base;
using Plugin.Media;
using PURPLE.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PURPLE.Views.PostElement
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormulairePostPage : AnimationPage
    {
        private uint animationLength = 300;
        public FormulairePostPage()
        {
            InitializeComponent();
          

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var currentNavPage = (Application.Current.MainPage as NavigationPage);
            var statusBarStyleManager = DependencyService.Get<IStatusBarStyleManager>();
            currentNavPage.BarBackgroundColor = Color.DarkCyan;
            statusBarStyleManager.SetLightTheme("#ffffff");
            statusBarStyleManager.SetNavigationBarColor("#ffffff");


        }

        /// <summary>
        ///  Masquer la liste de hashat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Device.InvokeOnMainThreadAsync(async () =>
            {
                
                await Task.WhenAll(
                    stacklist.TranslateTo(400,0,animationLength),
                    stacklist.FadeTo(0,animationLength)
                   );

               
            });
        }

        private  void SfButton_Clicked(object sender, EventArgs e)
        {
            Device.InvokeOnMainThreadAsync(async () =>
            {

                await Task.WhenAll(
                    stacklist.TranslateTo(0,0, animationLength),
                    stacklist.FadeTo(1, animationLength)
                   );


            });
        }


        /*
             /// <summary>
             /// Prendre une image en photo
             /// </summary>
             public async void TakePhoto()
             {
                 await CrossMedia.Current.Initialize();

                 if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                 {
                   await  DisplayAlert("No Camera", ":( No camera available.", "OK");
                     return;
                 }

                 var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                 {
                     AllowCropping = true,
                     // Directory = "Sample",
                     //  Name = "test.jpg"
                 }) ;

                 if (file == null)
                     return;

                // await DisplayAlert("File Location", file.Path, "OK");

                 img.Source = ImageSource.FromStream(() =>
                 {
                     var stream = file.GetStream();
                     return stream;
                 });
             }

             /*

             #region TappedGesture
             /// <summary>
             ///     Retour a la page precedente
             /// </summary>
             /// <param name="sender"></param>
             /// <param name="e"></param>
             private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
             {
                 await Navigation.PopAsync();
             }



             /// <summary>
             /// Chage le sens de la camera (avant ou arriere)
             /// </summary>
             /// <param name="sender"></param>
             /// <param name="e"></param>
             private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
             {
                 if (cameraView.CameraOptions == CameraOptions.Front)
                 {
                     cameraView.CameraOptions = CameraOptions.Back;
                 }
                 else
                 {
                     cameraView.CameraOptions = CameraOptions.Front;
                 }

             }

             /// <summary>
             /// Activer ou desactvier le flash de la camera
             /// </summary>
             /// <param name="sender"></param>
             /// <param name="e"></param>
             private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
             {
                 if (cameraView.FlashMode == CameraFlashMode.Off)
                 {
                     cameraView.FlashMode = CameraFlashMode.On;
                     BtnFlash.FontFamily = "fas";
                 }
                 else
                 {
                     cameraView.FlashMode = CameraFlashMode.Off;
                     BtnFlash.FontFamily = "fal";
                 }
             }

             /// <summary>
             ///  Changer le Mode de la camera ( video ou audio)
             /// </summary>
             /// <param name="sender"></param>
             /// <param name="e"></param>
             private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
             {

                  if(cameraView.CaptureMode==CameraCaptureMode.Video)
                 {
                     BtnChange.IsVisible=false;
                     BtnChange.IsEnabled=false;
                     BtnChange1.IsVisible = true;
                     BtnChange1.IsEnabled = true;
                     cameraView.CaptureMode= CameraCaptureMode.Photo;
                     cameraView.FlashMode = CameraFlashMode.Off;
                     BtnFlash.FontFamily = "fal";
                    ;

                 }
                 else
                 {
                     BtnChange.IsVisible = true;
                     BtnChange.IsEnabled = true;
                     BtnChange1.IsVisible = false;
                     BtnChange1.IsEnabled = false;
                     cameraView.CaptureMode = CameraCaptureMode.Video;
                     cameraView.FlashMode = CameraFlashMode.Off;
                     BtnFlash.FontFamily = "fal";

                 }
             }

             #endregion

             /// <summary>
             ///  Capture d'image et Photos 
             /// </summary>
             /// <param name="sender"></param>
             /// <param name="e"></param>
             private void CaptureImage(object sender, EventArgs e)
             {
                 cameraView.Shutter();


             }
             private void RecordVideo(object sender, EventArgs e)
             {
                 cameraView.Shutter();
             }
             private void StopVideo(object sender, EventArgs e)
             {
                 cameraView.Shutter();
             }
             /// <summary>
             /// Prise de l'image ou de la video
             /// </summary>
             /// <param name="sender"></param>
             /// <param name="e"></param>
             private void cameraView_MediaCaptured(object sender, MediaCapturedEventArgs e)
             {
                 switch (cameraView.CaptureMode)
                 {
                     default:
                     case CameraCaptureMode.Default:
                     case CameraCaptureMode.Photo:
                         previewVideo.IsVisible = false;
                         previewPicture.IsVisible = true;
                         previewPicture.Rotation = e.Rotation;
                         previewPicture.Source = e.Image;
                         gridShowMedia.TranslateTo(0, 0);
                         break;
                     case CameraCaptureMode.Video:
                         previewPicture.IsVisible = false;
                         previewVideo.IsVisible = true;
                         previewVideo.Source = e.Video;
                         gridShowMedia.TranslateTo(0, 0);
                         break;
                 }
             }

             private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
             {
                 gridShowMedia.TranslateTo(400, 0);
             }
             */
    }
}