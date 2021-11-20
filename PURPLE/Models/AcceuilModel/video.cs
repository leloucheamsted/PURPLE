using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PURPLE.Models.AcceuilModel
{

    public class video : INotifyPropertyChanged
    {
        private string video_name;


        public video()
        {

        }
        public string Video_name
        {
            get { return video_name; }
            set { video_name = value; OnPropertyChanged("Video_name"); }
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
