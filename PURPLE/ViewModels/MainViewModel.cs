using PURPLE.Models;
using PURPLE.Models.AcceuilModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace PURPLE.ViewModels
{
    public  class MainViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        // class hastag value
        private ObservableCollection<hastags> hastag;

        // SetProperty hastag class
        public ObservableCollection<hastags> Hastags { get =>  hastag; set => SetProperty(ref hastag, value); }

        public MainViewModel()
        {

            // Liste de hashtag
            hastag = new ObservableCollection<hastags>
            {
                new hastags{hashtag_name="#entrepeneuriat"},
                new hastags{hashtag_name="#societé"},
                new hastags{hashtag_name="#technologie"},
                new hastags {hashtag_name="#buzz"},
                
                new hastags{hashtag_name="#marketing"}
            };
        }

        #region ICommad bloc
        public ICommand hashtagSelected { private set; get; }
        #endregion
        #region INotifyPropertyChanged Bloc
        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
