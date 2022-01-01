using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PURPLE.Models.MediaModel
{
    public class CameraMode : INotifyPropertyChanged
    {
        private bool isVideo;

        public CameraMode()
        {
            isVideo = false;
        }

        #region Properties
        public bool IsVideo
        {
            get { return isVideo; }
            set { isVideo = value; OnPropertyChanged("IsVideo"); }
        }
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
