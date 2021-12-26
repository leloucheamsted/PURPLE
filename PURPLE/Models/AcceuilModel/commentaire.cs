using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PURPLE.Models.AcceuilModel
{
    public class commentaire : INotifyPropertyChanged
    {
        #region variables
        private string comment; // Le commentaire
        private int nbrejaime; // Nombre de jaime du commentaire
        private string nomUtilisateur; // nom de celui qui reond
        private string avatar; // lien source la photo de profile
        private List<reponse> reponses; // Liste de reponse q'ua recue le commentaire
        private int nbreReponses; // Nombre de reponse qu'a recue le commentaire
        #endregion

        #region Constructeur
        public commentaire()
        {

        }
        #endregion

        #region Proprietes
        public string Comment
        {
            get { return comment; }
            set { comment = value; OnPropertyChanged("Comment"); }
        }
        public int NbreReponses
        {
            get { return nbreReponses; }
            set { nbreReponses = value; OnPropertyChanged("NbreReponses"); }
        }
        public string NomUtilisateur
        {
            get { return nomUtilisateur; }
            set { nomUtilisateur = value; OnPropertyChanged("NomUtilisateur"); }
        }
        public string Avatar
        {
            get { return avatar; }
            set { avatar = value; OnPropertyChanged("Avatar"); }
        }
        public List<reponse> Reponses
        {
            get { return reponses; }
            set { reponses = value; OnPropertyChanged("Reponses"); }
        }
        public int NbreJaime
        {
            get { return nbrejaime; }
            set {  nbrejaime = value; OnPropertyChanged("NbreJaime"); }
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
