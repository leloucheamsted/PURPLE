using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Text;

namespace PURPLE.Views.Home.AnimationListView
{
    public class ItemGeneratorExt : ItemGenerator
    {
        public SfListView listView;

        public ItemGeneratorExt(SfListView listView) : base(listView)
        {
            this.listView = listView;
        }

        protected override ListViewItem OnCreateListViewItem(int itemIndex, ItemType type, object data = null)
        {
            if (type == ItemType.Record)
                return new ListViewItemExt(this.listView);
            return base.OnCreateListViewItem(itemIndex, type, data);
        }
    }
}
