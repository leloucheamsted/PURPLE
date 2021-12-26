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
        private string nomUtilisateur; // nom de celui qui reond
        private string avatar; // lien source la photo de profile
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
        public string NomUtilisateur
        {
            get {  return nomUtilisateur; }
            set {  nomUtilisateur = value; OnPropertyChanged("NomUtilisateur"); }
        }
        public string Avatar
        {
            get { return avatar; }
            set {  avatar = value; OnPropertyChanged("Avatar"); }
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
