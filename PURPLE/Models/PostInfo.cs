using PURPLE.Models.AcceuilModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace PURPLE
{
    public class PostInfo : INotifyPropertyChanged
    {
        #region Variables
        private string nom; // nom de l'auteur de la publication
        private string ville; // ville de residence
        private string voirPlus; // Texte de publication
        private string avatar; // avatar de l'auteur
        private List<img> image; //  visuel de type Image de la publication
        private List<video> videos; // visuel de type video de la  pubication
        private string quesion; // visuel de type question de la publication
        private string btnPartager; // Bouton partager
        private string btnComment; // bouton commenter
        private string btnLiker; // bouton liker
        private int nbreLike; // nombre de like
        private int nbreComment; // nombre de commentaire
        private int nbrePartage; // nombre de partage
        private int typePost; // type de post(Image,texte,video)
        private bool likeStatut; // Le poster est liker ou pas 
        private List<commentaire> listcommentaire; // Liste de commentaires
        #endregion

        public Command<object> LikeCommand { private set; get; }
        #region constructeur
        public PostInfo()
        {
            LikeCommand = new Command<object>(LikePublicatioin);
        }
        #endregion

       
        #region Proprietes

        public List<commentaire> Listcommentaire
        {
            get { return listcommentaire; }
            set {  listcommentaire = value; OnPropertyChanged("ListCommentaire"); }
        }
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
        
        public List<img> Image
        {
            get { return image; }
            set {  image = value; OnPropertyChanged("Image"); }
        }
        public List <video> Videos
        {
            get { return videos; }
            set {  videos = value; OnPropertyChanged("Videos"); }
        }
        public string Quesion
        {
            get { return quesion; }
            set {  quesion = value; OnPropertyChanged("Question"); }
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
        public int TypePost
        {
            get { return typePost; }
            set {  typePost = value; OnPropertyChanged("TypePost"); }
        }
        public bool LikeStatut
        {
            get { return likeStatut; }
            set {  likeStatut = value; OnPropertyChanged("LikeStatut"); }
        }
        #endregion

        #region Proprietes privees
        private void LikePublicatioin(object obj)
        {
            if ((obj as PostInfo).LikeStatut == false)
            {
                (obj as PostInfo).LikeStatut = true;
                (obj as PostInfo).NbreLike += 1;
                Console.WriteLine("LIKE");
            }
            else
            {
                (obj as PostInfo).LikeStatut = false;
                (obj as PostInfo).NbreLike -= 1;
                Console.WriteLine("Dislike");
            }
            Console.WriteLine("Modification de l'etat du like");
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
