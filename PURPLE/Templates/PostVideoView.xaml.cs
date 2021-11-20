using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PURPLE.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostVideoView : Grid
    {
        public PostVideoView()
        {
            InitializeComponent();
        }
        /*
        void OnPlayPauseButtonClicked(object sender, EventArgs args)
        {
            if (video_player.CurrentState == MediaElementState.Stopped ||
                video_player.CurrentState == MediaElementState.Paused)
            {
                video_player.Play();
            }
            else if (video_player.CurrentState == MediaElementState.Playing)
            {
                video_player.Pause();
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if(video_player.Volume >0 && video_player.Volume<=1)
            {
                video_player.Volume = 0;
            }
            else if(video_player.Volume ==0)
            {
                video_player.Volume=1;
            }
        }

         private void  TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            //await control.FadeTo(0.4, 3, Easing.SinOut);
            Device.StartTimer(TimeSpan.FromSeconds(10), () =>
            {
                control.BackgroundColor = Color.Black;
                control.Opacity = 0.4;
                Btn_command.IsEnabled = false;
                return false;// Pour ne plus repeter l'action
            });
            

        } 
        */
    }
}