using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PURPLE.Models.AcceuilModel
{

    public class img : INotifyPropertyChanged
    {
        private string img_name;


        public img()
        {

        }
        public string Img_name
        {
            get { return img_name; }
            set { img_name = value; OnPropertyChanged("Img_name"); }
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
