using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PURPLE.Models.AcceuilModel
{
   
    public  class hastags : INotifyPropertyChanged
    {
        private string hashtag_name;


        public hastags()
        {

        }
        public string Hashtag_name
        {
            get { return hashtag_name; }
            set { hashtag_name = value; OnPropertyChanged("Hashtag_name"); }
        }


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
