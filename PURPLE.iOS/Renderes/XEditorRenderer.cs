using PURPLE.Controls;
using PURPLE.iOS;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinFormsEditor.Controls;

[assembly: ExportRenderer(typeof(XEditor), typeof(XEditorRenderer))]
namespace PURPLE.iOS
{
    public class XEditorRenderer : EntryRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            Control.Layer.BorderWidth = 0;
            Control.BorderStyle = UITextBorderStyle.None;
        }
    }
}