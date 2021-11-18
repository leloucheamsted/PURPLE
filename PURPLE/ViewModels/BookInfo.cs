using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PURPLE.ViewModels
{
    public class BookInfo : INotifyPropertyChanged
    {
        #region variable
        private string bookName;
        private string bookDesc;
        private bool isrefreshing;
        #endregion

        #region constructeur
        #endregion


        #region proprietes
        public string BookName
        {
            get { return bookName; }
            set
            {
                bookName = value;
                OnPropertyChanged("BookName");
            }
        }

        public string BookDescription
        {
            get { return bookDesc; }
            set
            {
                bookDesc = value;
                OnPropertyChanged("BookDescription");
            }
        }
        public bool Isrefreshing
        {
            get { return isrefreshing; }
            set { isrefreshing = value; OnPropertyChanged("Isrefreshing"); }
        }
        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
