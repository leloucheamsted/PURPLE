﻿using PURPLE.Views.Home;
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
    public partial class CustomLabel : ContentView
    {
        public CustomLabel()
        {
            InitializeComponent();
        }

        #region Bindable Property
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(TextProperty),
            returnType: typeof(string),
            declaringType: typeof(CustomLabel),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: TextPropertyChanged
            );

        public string Text
        {
            get { return (string)base.GetValue(TextProperty); }
            set { base.SetValue(TextProperty, value); }
        }

        //Show the read more label if word length > 100
        private static void TextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomLabel)bindable;
            if (newValue != null)
            {
                
                control.customLabel.Text = (string)newValue;
                if (control.customLabel.Text.Split().Length > 100)
                {
                    control.ShortTextVisible = true;
                    control.ReadMoreLabel = true;
                }
            }
        }
        #endregion

        public bool ReadMoreLabel { get; set; }
        private bool _shortTextVisible;
        public bool ShortTextVisible
        {
            get => _shortTextVisible;
            set { _shortTextVisible = value; ShortTextPropertyChanged(); }
        }

        //By Default show first 30 words.
        private void ShortTextPropertyChanged()
        { 
            if (Text != null)
            {
                if (ShortTextVisible)
                {
                    customLabel.Text = string.Join(" ", Text.Split().Take(100));
                  
                   
                    //var PopPost = new PostPage();
                    //App.Current.MainPage.Navigation.PushAsync(PopPost, true);
                }
                else
                {
                    customLabel.Text = Text;
                    
                }
            }
            
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var PopPost = new PostPage();
            App.Current.MainPage.Navigation.PushAsync(PopPost, true);
        }
    }

}
