using Xamarin.Forms;
using PURPLE.Controls;
using PURPLE.Droid.Helpers;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using Android.Content;

[assembly: ExportRenderer(typeof(XEditor), typeof(XEditorRenderer))]
namespace PURPLE.Droid.Helpers
{
    [System.Obsolete]
    public class XEditorRenderer : EditorRenderer
    {
        public XEditorRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
}