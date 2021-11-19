using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.ListView.XForms;
using PURPLE.Models;
using PURPLE.Views.ACCEUILVIEW;
using PURPLE.Models.AcceuilModel;

namespace PURPLE.ViewModels
{
    public class PostInfoViewModel : INotifyPropertyChanged
    {
        #region  Notes des Types de publications
        /*
         0 = publication de type image uniaue
         1 = publication de plusieurs images
         2 = publication de question 
         3 = publication d'une seule video
         4 = publication de plusieurs videos
         */
        #endregion

        #region variables
        private ObservableCollection<PostInfo> postsInfo;
        private ObservableCollection<hastags> Hastags;
        private bool isRefreshing;
        #endregion

        #region Constructeur
        public PostInfoViewModel()
        {
            GenerateSource();
            GetHastags();
            RefreshCommand = new Command<object>(PullToRefresh_Refreshing);
            VoirPlusCommand = new Command<object>(NavigateToReadMoreContent);
            LikeCommand = new Command<object>(LikePublicatioin);
            CommentCommand = new Command<object>(CommentPublicatioin);
        }
        #endregion

        #region Proprietes
        public ObservableCollection<PostInfo> Posts
        {
            get { return postsInfo; }
            set { postsInfo = value; }
        }
        public ObservableCollection <hastags> HastagsList
        {
            get { return Hastags; }
            set { Hastags = value; }
        }
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { isRefreshing = value; this.OnPropertyChanged("IsRefreshing"); }
        }

        public Command<object> RefreshCommand { get; set; }
        public Command<object> PartageCommand { get; set; }
        public Command<object> CommentCommand { get; set; }
        public Command<object> LikeCommand { get; set; }
        public Command<object> VoirPlusCommand { get; set; }
        #endregion

        #region Methodes Privees
        private async void PullToRefresh_Refreshing(object obj)
        {
            this.IsRefreshing = true;
            await Task.Delay(2000);
            var postsNameCount = this.PostsInfoName.Count() - 1;
            if ((this.Posts.Count - 1) == postsNameCount)
            {
                this.IsRefreshing = false;
                return;
            }
            var postsVilleCount = this.PostsInfoVille.Count() - 1;
            var postsVoirPlusCount = this.PostsInfoVoirPlus.Count() - 1;
            var postsImageCount = this.PostInfoImage.Count() - 1;
            var postVideoCount = PostInfoVideo.Count() - 1;
            var postQuestionCount = PostInfoQuestion.Count() - 1;
            for (int i = 0; i < 3; i++)
            {
                var postsCount = this.Posts.Count;
                var item = new PostInfo()
                {
                    Nom = PostsInfoName[postsNameCount - i],
                    Ville = PostsInfoVille[postsVilleCount - i],
                    VoirPlus = PostsInfoVoirPlus[postsVoirPlusCount - i],
                    Avatar = "avatar.jpg",
                    Image = PostInfoImage[postsImageCount-i],
                    Videos = PostInfoVideo[postVideoCount - i],
                    Quesion = PostInfoQuestion[postQuestionCount - i],
                    BtnPartager = "&#xf064;",
                    BtnLiker = "&#xf004;",
                    BtnComment = "&#xf4b6;",
                    NbreComment = 20,
                    NbreLike = 20,
                    NbrePartage = 20

                };
                #region Algo de choix de detection du type de publication
                if (PostInfoImage[postsImageCount - i].Count() == 0) // si la liste d'image est vide alors on a pas a faire a une publicatio nde type image(s)
                {
                    if (PostInfoVideo[postVideoCount - i].Count() == 0) // si la liste de video est vide alors on  a faire une question
                    {
                        item.TypePost = 2; // type Question
                    }
                    else if (PostInfoVideo[postVideoCount - i].Count() == 1) // si la publication contient une video
                    {
                        item.TypePost = 3; // alors on affiche une publica tion de type video
                    }
                    else if (item.Videos[i].Count() > 1) // si la publication contient plusieurs video
                    {
                        item.TypePost = 4; // utilisation d'un carousel de videos
                    }
                }
                else if (PostInfoImage[postsImageCount - i].Count() == 1) // si la liste n'a qu'un seul element alors c'est une publication d'une seul image
                {
                    item.TypePost = 0; // Publication d'image unique / pas de carouselView
                }
                else if (PostInfoImage[postsImageCount - i].Count() > 1) // si la publication a plusieurs images
                {
                    item.TypePost = 1; // utilisation du carouselView
                }
                #endregion

                this.Posts.Insert(0, item);
            }
            this.IsRefreshing = false;
        }

        private void NavigateToReadMoreContent(object obj)
        {
            var readMoreContentPage = new VoirPlusPage();
            readMoreContentPage.BindingContext = obj;
            App.Current.MainPage.Navigation.PushAsync(readMoreContentPage);
        }

        private async void LikePublicatioin(object obj)
        {
            var like= (obj as PostInfo).NbreLike;
            like += 1;
        }
        private async void CommentPublicatioin(object obj)
        {
            var like = (obj as PostInfo).NbreComment;
            like += 1;
        }
        #endregion

        #region GenerateSource
        internal ObservableCollection<PostInfo> GenerateSource()
        {
            postsInfo = new ObservableCollection<PostInfo>();
            
            var postsNameCount = PostsInfoName.Count() - 1;
            var postsVilleCount= PostsInfoVille.Count() - 1;
            var postsVoirPlusCount= PostsInfoVoirPlus.Count() - 1;
            var postImageCount=PostInfoImage.Count() - 1;
            var postVideoCount=PostInfoVideo.Count() - 1;
            var postQuestionCount=PostInfoQuestion.Count() - 1;
            for (int i = 0; i < 5; i++)
            {
                var post = new PostInfo()
                {
                    Nom = PostsInfoName[postsNameCount - i],
                    Ville = PostsInfoVille[postsVilleCount - i],
                    VoirPlus = PostsInfoVoirPlus[postsVoirPlusCount - i],
                    Avatar = "avatar.jpg",
                    Image = PostInfoImage[postImageCount -i],
                    Videos= PostInfoVideo[postVideoCount - i],
                    Quesion =PostInfoQuestion[postQuestionCount - i],
                    BtnPartager = "&#xf064;",
                    BtnLiker = "&#xf004;",
                    BtnComment = "&#xf4b6;",
                    NbreComment =20,
                    NbreLike=20,
                    NbrePartage=20


                };
                #region Algo de choix de detection du type de publication
                if (PostInfoImage[postImageCount - i].Count == 0) // si la liste d'image est vide alors on a pas a faire a une publicatio nde type image(s)
                {
                    if(PostInfoVideo[postVideoCount - i].Count() == 0) // si la liste de video est vide alors on  a faire une question
                    {
                        post.TypePost = 2; // type Question
                    }
                    else if (PostInfoVideo[postVideoCount - i].Count() == 1) // si la publication contient une video
                    {
                        post.TypePost= 3; // alors on affiche une publica tion de type video
                    }
                    else if (PostInfoVideo[postVideoCount - i].Count() > 1) // si la publication contient plusieurs video
                    {
                        post.TypePost = 4; // utilisation d'un carousel de videos
                    }
                }
                 else if (PostInfoImage[postImageCount - i].Count() == 1) // si la liste n'a qu'un seul element alors c'est une publication d'une seul image
                {
                    post.TypePost = 0; // Publication d'image unique / pas de carouselView
                }
                else if(PostInfoImage[postImageCount - i].Count()>1) // si la publication a plusieurs images
                {
                    post.TypePost= 1; // utilisation du carouselView
                }
                #endregion
                postsInfo.Insert(0, post);
            }
           
            return postsInfo;
        }
        internal ObservableCollection<hastags> GetHastags()
        {
            Hastags = new ObservableCollection<hastags>();
            for (int i=0;i<hashtag_name.Count(); i++)
            {
                var hash = new hastags()
                {
                    Hashtag_name = hashtag_name[i],
                };
                Hastags.Insert(i, hash);
            }
            return Hastags;

        }
        #endregion

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

        #region PostsInfo
        internal string[] PostsInfoName = new string[]
        {
            "Lelouche Amsted",
            "Cabraule Ketch",
            "Zeus Pegazus",
            "Alfred ruch",
            "Hiro Vam",
            "Grand orchert",
            "Lelouche Amsted",
            "Cabraule Ketch",
            "Zeus Pegazus",
            "Alfred ruch",
            "Hiro Vam",
            "Grand orchert",
            "Lelouche Amsted",
            "Cabraule Ketch",
            "Zeus Pegazus",
            "Alfred ruch",
            "Hiro Vam",
            "Grand orchert",
            "Lelouche Amsted",
            "Cabraule Ketch",
            "Zeus Pegazus",
            "Alfred ruch",
            "Hiro Vam",
            "Grand orchert",
            "Lelouche Amsted",
            "Cabraule Ketch",
            "Zeus Pegazus",
            "Alfred ruch",
            "Hiro Vam",
            "Grand orchert",

        };
        internal string[] PostsInfoVille = new string[]
        {
            "Douala,Ndogpassi",
            "Douala,New-bell",
            "Yaoude,nvan",
            "Bafoussam,Marche",
            "Loum,Total",
            "Manjo,Tribune",
            "Douala,Ndogpassi",
            "Douala,New-bell",
            "Yaoude,nvan",
            "Bafoussam,Marche",
            "Loum,Total",
            "Manjo,Tribune",
            "Douala,Ndogpassi",
            "Douala,New-bell",
            "Yaoude,nvan",
            "Bafoussam,Marche",
            "Loum,Total",
            "Manjo,Tribune",
            "Douala,Ndogpassi",
            "Douala,New-bell",
            "Yaoude,nvan",
            "Bafoussam,Marche",
            "Loum,Total",
            "Manjo,Tribune",
            "Douala,Ndogpassi",
            "Douala,New-bell",
            "Yaoude,nvan",
            "Bafoussam,Marche",
            "Loum,Total",
            "Manjo,Tribune",
        };
        internal string[] PostsInfoVoirPlus = new string[] {
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
            "Syncfusion is always pleased to have the opportunity to talk to you in person. This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference, May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference. We will have a booth at both with three of our developers and our director of sales ready to answer any questions and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, Jayakrishnan, Soundara, and Christian!",
        };
        internal List<List<string>> PostInfoImage = new List<List<string>>{
            new List<string>{ "imagePost.jpg" ,"imagePost.jpg","imagePost.jpg" },
            new List<string> {"imagePost.jpg"},
            new List<string> {},
            new List<string> {},
            new List<string> {},
            new List<string> {},
            new List<string>{ "imagePost.jpg" ,"imagePost.jpg","imagePost.jpg" },
            new List<string> {"imagePost.jpg"},
            new List<string> {},
            new List<string> {},
            new List<string> {},
            new List<string> {},
            new List<string>{ "imagePost.jpg" ,"imagePost.jpg","imagePost.jpg" },
            new List<string> {"imagePost.jpg"},
            new List<string> {},
            new List<string> {},
            new List<string> {},
            new List<string> {},
            new List<string>{ "imagePost.jpg" ,"imagePost.jpg","imagePost.jpg" },
            new List<string> {"imagePost.jpg"},
            new List<string> {},
            new List<string> {},
            new List<string> {},
            new List<string> {},
            new List<string>{ "imagePost.jpg" ,"imagePost.jpg","imagePost.jpg" },
            new List<string> {"imagePost.jpg"},
            new List<string> {},
            new List<string> {},
            new List<string> {},
            new List<string> {},
        };
        internal List<List<string>> PostInfoVideo = new List<List<string>>{
            new List<string> {},
            new List<string> {},
            new List<string>{"videoTest.mp4" , "videoTest.mp4", "videoTest.mp4" },
            new List<string> {"videoTest.mp4"},
            new List<string> {},
            new List<string> {},
              new List<string> {},
            new List<string> {},
            new List<string>{"videoTest.mp4" , "videoTest.mp4", "videoTest.mp4" },
            new List<string> {"videoTest.mp4"},
            new List<string> {},
            new List<string> {},
              new List<string> {},
            new List<string> {},
            new List<string>{"videoTest.mp4" , "videoTest.mp4", "videoTest.mp4" },
            new List<string> {"videoTest.mp4"},
            new List<string> {},
            new List<string> {},
              new List<string> {},
            new List<string> {},
            new List<string>{"videoTest.mp4" , "videoTest.mp4", "videoTest.mp4" },
            new List<string> {"videoTest.mp4"},
            new List<string> {},
            new List<string> {},
              new List<string> {},
            new List<string> {},
            new List<string>{"videoTest.mp4" , "videoTest.mp4", "videoTest.mp4" },
            new List<string> {"videoTest.mp4"},
            new List<string> {},
            new List<string> {},
        };
        internal string[] PostInfoQuestion = new string[]{
            "",
            "",
            "",
            "",
            "Comment allez-vous?",
            "Comment allez-vous?",
              "",
            "",
            "",
            "",
            "Comment allez-vous?",
            "Comment allez-vous?",
              "",
            "",
            "",
            "",
            "Comment allez-vous?",
            "Comment allez-vous?",
              "",
            "",
            "",
            "",
            "Comment allez-vous?",
            "Comment allez-vous?",
              "",
            "",
            "",
            "",
            "Comment allez-vous?",
            "Comment allez-vous?",
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
