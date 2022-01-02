using PURPLE.Views.PostElement;
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
    public partial class PostElement : ContentPage
    {
        private uint durerAnimation = 600;
        public PostElement()
        {
            InitializeComponent();
        }

        private async void reussite_postBtn_TouchUp(object sender, EventArgs e)
        {
            var formulaire = new FormulairePostPage();
            await App.Current.MainPage.Navigation.PushAsync(formulaire);
        }
    }
}