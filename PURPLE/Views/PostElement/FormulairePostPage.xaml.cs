using FormsControls.Base;
using Plugin.Media;
using PURPLE.Interface;
using Syncfusion.XForms.EffectsView;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        //
        private void CustomEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

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
            #region sfview
            SfEffectsView sfv = new SfEffectsView()
            {
          Margin = new Thickness(5),
              
          Padding = new Thickness(5),
          BackgroundColor = Color.FromHex("#DCE8F6"),
          TouchUpEffects = SfEffects.Ripple,
           RippleColor = Color.FromHex("#0F2D52"),
            CornerRadius = 20,
            HorizontalOptions = LayoutOptions.StartAndExpand,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            
        };
            #endregion

            #region Label
            Label lab = new Label()
            {
                FontFamily="MetroRegular",
                FontSize=18,
                HorizontalOptions=LayoutOptions.Center,
                VerticalOptions=LayoutOptions.Center,
                TextColor=Color.FromHex("#000000"),
                Text ="Lelouche"
            };
            #endregion

            /* Added lABEL IN DFVIEW Listcompetences
            sfv.Content=lab;
           flexLayoutCompetences.Children.Add(sfv);
            Debug.WriteLine("Adddded");
            */
        }

        /// <summary>
        ///  Fermeture de la Page de competenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Device.InvokeOnMainThreadAsync(async () =>
            {

                await Task.WhenAll(
                    Listcompetences.TranslateTo(800, 0, animationLength),
                    Listcompetences.FadeTo(0, animationLength)
                   );


            });
        }

        /// <summary>
        /// Selection de la data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void date_DateSelected(object sender, DateChangedEventArgs e)
        {
           
            TimePicker TimePicker = new TimePicker();
           var h= TimePicker.Time= DateTime.Now.TimeOfDay;
            Debug.WriteLine(date.Date.ToString());
            Debug.WriteLine(h.ToString());


        }
    }
}