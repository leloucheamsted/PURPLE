using PURPLE.Views.ACCEUILVIEW;
using Syncfusion.XForms.EffectsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PURPLE.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FooterCustom : ContentView
    {
        public FooterCustom()
        {
            InitializeComponent();
        }

       
       private void SfEffectsView_TouchUp(object sender, EventArgs e)
        {
            var obj = ((SfEffectsView)sender).BindingContext as PostInfo;
            var readMoreContentPage = new VoirPlusPage(obj);
            App.Current.MainPage.Navigation.PushAsync(readMoreContentPage);
        }
    }
}