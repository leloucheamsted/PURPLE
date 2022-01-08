using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace PURPLE.Models.PostTypeModel
{
    public class Reussite : INotifyPropertyChanged
    {
        #region variables
        private string _id;
        private string intitule;
        private string description;
        private string lieu;
        private string Date;
        private ObservableCollection<string> competences;
        private ObservableCollection<Image> images;
        MediaElement video;
        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
