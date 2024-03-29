﻿using PURPLE.Interface;
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
    public partial class EmploiPage : ContentPage
    {
        public EmploiPage()
        {
            InitializeComponent();
        }

        protected  override void OnAppearing()
        {
            base.OnAppearing();
            var currentNavPage = (Application.Current.MainPage as NavigationPage);
            var statusBarStyleManager = DependencyService.Get<IStatusBarStyleManager>();
            currentNavPage.BarBackgroundColor = Color.LightBlue;
            statusBarStyleManager.SetLightTheme("#ffffff");
            statusBarStyleManager.SetNavigationBarColor("#ffffff");
        }
    }
}