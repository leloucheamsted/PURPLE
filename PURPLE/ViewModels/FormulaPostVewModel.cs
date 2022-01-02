using PURPLE.Views.PostElement;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace PURPLE
{
    public class FormulaPostVewModel : INotifyPropertyChanged
    {
        #region variables
        ObservableCollection<string> listhastag; // Liste des # 
        ObservableCollection<string> listhastagsForm; // Liste Hashtags du formulaires
          #endregion

        #region constructeur
        public FormulaPostVewModel()
        {
            GetHastags();
            AddHashtagCommand=new Command<object>(showListHashtag);
        }
        #endregion

        #region Proprietes
        public ObservableCollection<string> Listhastag
        {
            get { return listhastag; }
            set {  listhastag = value; OnPropertyChanged("Listhastag"); }
        }
        public ObservableCollection<string> ListhastagForm
        {
            get { return listhastagsForm; }
            set { listhastagsForm = value; OnPropertyChanged("ListhastagForm"); }
        }

        public Command<object> AddHashtagCommand { get; set; }
        #endregion

        #region Methodes Prives
        private void showListHashtag(object obj)
        {
            var ob = obj as string;
            listhastag.Add(ob);
        }
        #endregion
        internal ObservableCollection<string> GetHastags()
        {
            Listhastag = new ObservableCollection<string>();
            for (int i = 0; i < hashtag_name.Count(); i++)
            {

                listhastag.Add(hashtag_name[i]);
            }
            return Listhastag;
        }

        #region HashtagList
        internal string[] hashtag_name = new string[]
        {
            "#entrepeneuriat",
            "#societé",
            "#technologie",
            "#marketing",
            "#buzz",

        };
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
