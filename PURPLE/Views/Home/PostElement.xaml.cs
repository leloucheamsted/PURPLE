using FormsControls.Base;
using PURPLE.Views.PostElement;
using Rg.Plugins.Popup.Extensions;
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
    public partial class PostElement : AnimationPage
    {
      //  private uint durerAnimation = 600;
        public PostElement()
        {
            InitializeComponent();
        }

        private async void reussite_postBtn_TouchUp(object sender, EventArgs e)
        {
            var formulaire = new FormulairePostReussitePage();
            await App.Current.MainPage.Navigation.PushAsync(formulaire);
        }

        private async void idee_postBtn_AnimationCompleted(object sender, EventArgs e)
        {
            var formulaire= new FormulairePostIdeaPage();
            await App.Current.MainPage.Navigation.PushAsync(formulaire);
        }

        private async void question_postBtn_AnimationCompleted(object sender, EventArgs e)
        {
            var formulaire = new FomulairePostAuestionPage();
            await App.Current.MainPage.Navigation.PushAsync(formulaire);
        }

        private async void post_postBtn_AnimationCompleted(object sender, EventArgs e)
        {
         
          //  var formulaire = new FormulairePostPage();
           await App.Current.MainPage.Navigation.PushAsync(new FormulairePostPage());
        }

      
    }

}