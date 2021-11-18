using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace PURPLE.Models
{
    public class PostInfo : INotifyPropertyChanged
    {
        #region Variables
        private string nom;
        private string ville;
        private string voirPlus;
        private string avatar;
        private string image;
        private string btnPartager;
        private string btnComment;
        private string btnLiker;
        private int nbreLike;
        private int nbreComment;
        private int nbrePartage;
        #endregion

        #region constructeur
        public PostInfo()
        {

        }
        #endregion

        #region Proprietes
        public string Nom
        {
            get { return nom; }
            set { nom = value; OnPropertyChanged("Nom"); }
        }
        public string Ville
        {
            get { return ville; }
            set {  ville = value; OnPropertyChanged("Ville"); }
        }
        public string Avatar
        {
            get { return avatar; }
            set {  avatar = value; OnPropertyChanged("Avatar"); }
        }
        public string Image
        {
            get { return image; }
            set {  image = value; OnPropertyChanged("Image"); }
        }
       
        public string VoirPlus
        {
            get { return voirPlus; }
            set { voirPlus = value; OnPropertyChanged("VoirPlus"); }
        }
        public string BtnPartager
        {
            get { return btnPartager; }
            set { btnPartager = value; OnPropertyChanged("BtnPartager");}
        }
        public string BtnLiker
        {
            get { return btnLiker; }
            set { btnLiker = value; OnPropertyChanged("BtnLiker"); }
        }
        public string BtnComment
        {
            get { return btnComment; }
            set {  btnComment = value; OnPropertyChanged("BtnComment"); }
        }
        public int NbreLike
        {
            get { return nbreLike; }
            set {  nbreLike = value; OnPropertyChanged("NbreLike"); }
        }
        public int NbrePartage
        {
            get { return nbrePartage; }
            set {  nbrePartage = value; OnPropertyChanged("NbrePartage"); }
        }
        public int NbreComment
        {
            get { return nbreComment; }
            set {  nbreComment = value; OnPropertyChanged("NbreComment"); }
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
