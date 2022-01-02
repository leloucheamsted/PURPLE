using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.SfPullToRefresh.XForms.iOS;
using Syncfusion.XForms.iOS.EffectsView;
using UIKit;

namespace PURPLE.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            //Xam.Forms.VideoPlayer.iOS.VideoPlayerRenderer.Init();
            Syncfusion.XForms.iOS.EffectsView.SfEffectsViewRenderer.Init();
            Rg.Plugins.Popup.Popup.Init();
            SfListViewRenderer.Init();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            FormsControls.Touch.Main.Init();
            Syncfusion.XForms.iOS.Expander.SfExpanderRenderer.Init();
            SfEffectsViewRenderer.Init();
            Syncfusion.XForms.iOS.Cards.SfCardViewRenderer.Init();
            Syncfusion.XForms.iOS.Core.SfAvatarViewRenderer.Init();
            SfPullToRefreshRenderer.Init();
            //global::Xamarin.Forms.FormsMaterial.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
