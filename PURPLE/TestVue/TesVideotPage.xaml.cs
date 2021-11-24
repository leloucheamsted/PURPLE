using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PURPLE.TestVue
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TesVideotPage : ContentPage
    {
        public TesVideotPage()
        {
            InitializeComponent();
            if(video_player.CurrentState == MediaElementState.Playing)
            {
                video_player.Stop();
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (video_player.CurrentState == MediaElementState.Playing)
            {
                video_player.Stop();
            } 

        }
    }
}