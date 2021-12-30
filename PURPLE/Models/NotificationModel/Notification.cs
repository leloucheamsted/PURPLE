using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PURPLE.Models.NotificationModel
{
    public class Notification : INotifyPropertyChanged
    {
        #region Sylabus
        /*
         * TYPE DE NOTIFICATIONS
         *  Notification : reaction
         *  Notification : post
         *  Notification : commentaire
         *  Notification : reponse 
         *  Notification : reussite
         *  Notification : purple
         *  Notification : idee
         */
        #endregion

        #region variables
        private string id; // id de la notification
        private string content; // contenue de la notification
        private string typeNotification; // type de notification 
        private string avatarNotification; // avatar de l'intituler de la notification
        private string dateNotification; // Dat de crration de la notification  n
        #endregion

        #region constructeur
        public Notification()
        {

        }
        #endregion

        #region Proprietes
        public string Id 
        { 
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }
        public string Content
        {
            get { return content; }
            set {  content = value; OnPropertyChanged("Content"); }
        }
        public string TypeNotification
        {
            get { return typeNotification; }
            set {  typeNotification = value; OnPropertyChanged("TypeNotification"); }
        }
        public string AvatarNotification
        {
            get { return avatarNotification; }
            set { avatarNotification = value; OnPropertyChanged(AvatarNotification); }
        }

        public string DateNotification
        {
            get { return dateNotification; }
            set { dateNotification = value; OnPropertyChanged(dateNotification); }
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
