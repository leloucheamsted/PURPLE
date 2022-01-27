using FormsControls.Base;
using Plugin.Media;
using Plugin.Media.Abstractions;
using PURPLE.Interface;
using PURPLE.Views.Home;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PURPLE.Views.LoginSignUp.SignUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormSignUpPage : AnimationPage
    {
        private bool _isLoading =false;

        public bool IsLoading //Binded to ActivityIndicator
        {
            get { return _isLoading; }
            private set
            {
                _isLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }

        public FormSignUpPage()
        {
            BindingContext = this;
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

        private async void BackButton_AnimationCompleted(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void SexeBtn_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet(null, null, null, "Masculin", "Féminin");
            SexeBtn.Text=action;
        }

        private async void profil_btn1_AnimationCompleted(object sender, EventArgs e)
        {
            //avatarImg
            string action = await DisplayActionSheet(null, null, null, "Selectionner une photo", "Prendre une photo");

            if (action == "Selectionner une photo")
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                    return;
                }
                var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    //  PhotoSize = PhotoSize.Full,
                    //  SaveMetaData = true
                });
                avatarImg.ImageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
            }
            else if(action == "Prendre une photo")
            {
                await CrossMedia.Current.Initialize();


                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {

                });

                if (file == null)
                    return;


                avatarImg.ImageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
            }
        }

        private void date_DateSelected(object sender, DateChangedEventArgs e)
        {
          
                TimePicker TimePicker = new TimePicker();
                var h = DateTime.Now.ToString("HH:mm");
                DateBtn.Text = date.Date.ToString("dd/MM/yyy");
                Debug.WriteLine(h);



            
        }

       
    }
}