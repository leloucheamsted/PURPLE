using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PURPLE.Models.AcceuilModel
{
    public class reponse  : INotifyPropertyChanged
    {
        #region variables
        private string response; // La reponse au commentaire
        private int nbreJaimeReponse; // Nombre de reaction de la reponse
        #endregion

        #region constructeur
        public reponse()
        {

        }
        #endregion

        #region Propietes
        public string Response
        {
            get { return response; }
            set { response = value; OnPropertyChanged("Response"); }
        }
        public int NbreJaimeReponse
        {
            get {  return nbreJaimeReponse;}
            set { nbreJaimeReponse = value; OnPropertyChanged("NbreJaimeReponse"); }
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
