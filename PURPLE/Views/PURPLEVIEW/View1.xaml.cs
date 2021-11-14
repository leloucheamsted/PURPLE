using PURPLE.LoginSignUp.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PURPLE.Views.PURPLEVIEW
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class View1 : Page
    {
        public View1()
        {
            InitializeComponent();
        }

        private async Task TapGestureRecognizer_TappedAsync(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "You have been alerted", "OK");

        }
    }
}