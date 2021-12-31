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
    public partial class TabbedNavPage : ExtendedTabbedPage
    {
        int lastPage = 0;
        int currentPage = 1;
        public TabbedNavPage()
        {
            InitializeComponent();
            this.SelectedItem = Children[1];
            /*
            this.CurrentPageChanged += async (object sender, EventArgs e) => {
                var i = this.Children.IndexOf(this.CurrentPage);
                lastPage = currentPage;
                currentPage = i;
                if (this.CurrentPage == Children[2])
                {
                    currentPage = lastPage;
                   
                    var PopupPost = new PopupPost();
                    await App.Current.MainPage.Navigation.PushPopupAsync(PopupPost);
                    this.SelectedItem = Children[currentPage];
                }
               
                System.Diagnostics.Debug.WriteLine("lastPage  Page No:" + lastPage);
                System.Diagnostics.Debug.WriteLine("CurretPage Page No:" + currentPage);
               
            };*/
          //  PopupAdd();
        }

        private async void PopupAdd()
        {
            if(this.SelectedItem == this.Children[2])
            {
                SelectedItem = this.Children[lastPage];
                var PopupPost = new PopupPost();
                await App.Current.MainPage.Navigation.PushPopupAsync(PopupPost);

            }
        }
    }
}