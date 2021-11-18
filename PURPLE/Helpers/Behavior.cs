using Syncfusion.DataSource;
using Syncfusion.ListView.XForms;
using Syncfusion.SfPullToRefresh.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PURPLE
{
    #region PullToRefreshBehavior

    public class SfListViewPullToRefreshBehavior : Behavior<ContentPage>
    {
        #region Fields

        private SfPullToRefresh pullToRefresh = null;
        private Picker picker;

        #endregion

        #region Overrides

        protected override void OnAttachedTo(ContentPage bindable)
        {
            pullToRefresh = bindable.FindByName<SfPullToRefresh>("pullToRefresh");
            picker = bindable.FindByName<Picker>("transitionTypePicker");
            picker.Items.Add("SlideOnTop");
            picker.Items.Add("Push");
            picker.SelectedIndex = 1;
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            picker.SelectedIndexChanged -= Picker_SelectedIndexChanged;
            pullToRefresh = null;
            picker = null;
            base.OnDetachingFrom(bindable);
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picker.SelectedIndex == 0)
            {
                pullToRefresh.RefreshContentThreshold = 0;
                pullToRefresh.TransitionMode = TransitionType.SlideOnTop;
            }
            else
            {
                pullToRefresh.RefreshContentThreshold = 50;
                pullToRefresh.TransitionMode = TransitionType.Push;
            }
        }

        #endregion
    }

    #endregion
}