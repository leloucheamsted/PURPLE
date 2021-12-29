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
using System.Windows.Input;
using System.Diagnostics;

namespace PURPLE
{
    public class PostInfoViewModel : INotifyPropertyChanged
    {
        #region  Notes des Types de publications 
        /*
         0 = publication de type image unique
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
        public ObservableCollection<hastags> HastagsList
        {
            get { return Hastags; }
            set { Hastags = value; }
        }
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { isRefreshing = value; this.OnPropertyChanged("IsRefreshing"); }
        }

        public  Command<object> RefreshCommand { get; set; }
        public Command<object> PartageCommand { get; set; }
        public Command<object> CommentCommand { get; set; }
        public Command<object> LikeCommand { get; set; }
        public Command<object> VoirPlusCommand { get; set; }
        public Command<object> CommentCommandNav { get; set; }
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
            var postTypeCount = PostInfoType.Count() - 1;
            var postLikeStatutCount = PostInfoLikeStatut.Count() - 1;
           
            for (int i = 0; i < 3; i++)
            {
                var postsCount = this.Posts.Count;
                var item = new PostInfo()
                {
                    Nom = PostsInfoName[postsNameCount - i],
                    Ville = PostsInfoVille[postsVilleCount - i],
                    VoirPlus = PostsInfoVoirPlus[postsVoirPlusCount - i],
                    Avatar = "avatar.jpg",
                    Image = PostInfoImage[postsImageCount - i],
                    Videos = PostInfoVideo[postVideoCount - i],
                    Quesion = PostInfoQuestion[postQuestionCount - i],
                    TypePost = PostInfoType[postTypeCount - i],
                    LikeStatut = PostInfoLikeStatut[postLikeStatutCount - i],
                    Listcommentaire=PostInfoComment,
                    BtnPartager = "&#xf064;",
                    BtnLiker = "&#xf004;",
                    BtnComment = "&#xf4b6;",
                    
                    NbreLike = 20,
                    NbrePartage = 20

                };

                int nb_c = item.Listcommentaire.Count(); // nombrre de commentaire du post
                item.NbreComment = nb_c;
                for (int a = 0;a < nb_c - 1; a++)
                {
                    item.Listcommentaire[a].NbreReponses = item.Listcommentaire[a].Reponses.Count(); // nbre de reponses de chaque commentaire
                }
                this.Posts.Insert(0, item);
            }
            this.IsRefreshing = false;

        }

        private void  NavigateToReadMoreContent(object obj)
        {
            var ob = obj as PostInfo;
            var readMoreContentPage = new VoirPlusPage(ob);
            App.Current.MainPage.Navigation.PushAsync(readMoreContentPage);
        }

        private void LikePublicatioin(object obj)
        {
            if ((obj as PostInfo).LikeStatut == false)
            {
                (obj as PostInfo).LikeStatut = true;
                (obj as PostInfo).NbreLike += 1;
                Console.WriteLine("LIKE");
            } else
            {
                (obj as PostInfo).LikeStatut = false;
                (obj as PostInfo).NbreLike -= 1;
                Console.WriteLine("Dislike");
            }
            Console.WriteLine("Modification de l'etat du like");
        }
        private  void CommentPublicatioin(object obj)
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
            var postsVilleCount = PostsInfoVille.Count() - 1;
            var postsVoirPlusCount = PostsInfoVoirPlus.Count() - 1;
            var postImageCount = PostInfoImage.Count() - 1;
            var postVideoCount = PostInfoVideo.Count() - 1;
            var postQuestionCount = PostInfoQuestion.Count() - 1;
            var postTypeCount = PostInfoType.Count() - 1;
            var postLikeStatutCount = PostInfoLikeStatut.Count() - 1;
            var postinfoComment= PostInfoComment.Count() - 1;
            for (int i = 0; i < 5; i++)
            {
                var post = new PostInfo()
                {
                    Nom = PostsInfoName[postsNameCount - i],
                    Ville = PostsInfoVille[postsVilleCount - i],
                    VoirPlus = PostsInfoVoirPlus[postsVoirPlusCount - i],
                    Avatar = "avatar.jpg",
                    Image = PostInfoImage[postImageCount - i],
                    Videos = PostInfoVideo[postVideoCount - i],
                    Quesion = PostInfoQuestion[postQuestionCount - i],
                    TypePost = PostInfoType[postTypeCount - i],
                    LikeStatut = PostInfoLikeStatut[postLikeStatutCount - i],
                    Listcommentaire = PostInfoComment ,
                    BtnPartager = "&#xf064;",
                    BtnLiker = "&#xf004;",
                    BtnComment = "&#xf4b6;",
                    NbreLike = 20,
                    NbrePartage = 20


                };
               int nb_c= post.Listcommentaire.Count(); // nombrre de commentaire du post
                post.NbreComment = nb_c;
                for (int a = 0; a < nb_c - 1; a++)
                {
                    post.Listcommentaire[a].NbreReponses = post.Listcommentaire[a].Reponses.Count(); // nbre de reponses de chaque commentaire
                }
                postsInfo.Insert(0, post);
            }
            LikeCommand = new Command<object>(LikePublicatioin);
            return postsInfo;
        }
        internal ObservableCollection<hastags> GetHastags()
        {
            Hastags = new ObservableCollection<hastags>();
            for (int i = 0; i < hashtag_name.Count(); i++)
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
        internal List<List<img>> PostInfoImage = new List<List<img>>{
            new List<img> {new img { Img_name= "imagePost.jpg" } ,new img { Img_name= "imagePost.jpg" } },
new List<img> {new img { Img_name = "imagePost.jpg" },new img { Img_name= "imagePost.jpg" } },
            new List<img> {},
            new List<img> {},
            new List<img> {},
            new List<img> {},
            new List<img> {new img { Img_name= "imagePost.jpg" } },
new List<img> {new img { Img_name = "imagePost.jpg" },new img { Img_name= "imagePost.jpg" } },
            new List<img> {},
            new List<img> {},
            new List<img> {},
            new List<img> {},
            new List<img> {new img { Img_name= "imagePost.jpg" },new img { Img_name= "imagePost.jpg" } },
new List<img> {new img { Img_name = "imagePost.jpg" } ,new img { Img_name= "imagePost.jpg" } },
            new List<img> {},
            new List<img> {},
            new List<img> {},
            new List<img> {},
new List<img> {new img { Img_name = "imagePost.jpg" },new img { Img_name= "imagePost.jpg" } },
            new List<img> {new img { Img_name= "imagePost.jpg" } ,new img { Img_name= "imagePost.jpg" } },
            new List<img> {},
            new List<img> {},
            new List<img> {},
            new List<img> {},
            new List<img> {new img { Img_name = "imagePost.jpg" },new img { Img_name= "imagePost.jpg" } },
            new List<img>{ new img { Img_name= "imagePost.jpg" },new img { Img_name= "imagePost.jpg" } },  
            new List<img> {},
            new List<img> {},
            new List<img> {},
           
        };
        internal List<List<video>> PostInfoVideo = new List<List<video>>{
            new List<video> {},
            new List<video> {},
            new List<video>{ new video { Video_name= "ms-appx:///videoTest.mp4" }, new video { Video_name = "ms-appx:///videoTest.mp4" },  new video { Video_name= "ms-appx:///videoTest.mp4" } },
            new List<video>  {new video { Video_name= "ms-appx:///videoTest.mp4" } },
            new List<video> {},
            new List<video> {},
            new List<video> {},
            new List<video> {},
            new List<video>{ new video { Video_name= "ms-appx:///videoTest.mp4" }, new video { Video_name = "ms-appx:///videoTest.mp4" },  new video { Video_name= "ms-appx:///videoTest.mp4" } },
            new List<video>  {new video { Video_name= "ms-appx:///videoTest.mp4" } },
            new List<video> {},
            new List<video> {},
            new List<video> {},
            new List<video> {},
            new List<video>{ new video { Video_name= "ms-appx:///videoTest.mp4" }, new video { Video_name = "ms-appx:///videoTest.mp4" },  new video { Video_name= "ms-appx:///videoTest.mp4" } },
            new List<video>  {new video { Video_name= "ms-appx:///videoTest.mp4" } },
            new List<video> {},
            new List<video> {},
            new List<video> {},
            new List<video> {},
            new List<video>{ new video { Video_name= "ms-appx:///videoTest.mp4" }, new video { Video_name = "ms-appx:///videoTest.mp4" },  new video { Video_name= "ms-appx:///videoTest.mp4" } },
            new List<video>  {new video { Video_name= "ms-appx:///videoTest.mp4" } },
            new List<video> {},
            new List<video> {},
            new List<video> {},
            new List<video> {},
            new List<video>{ new video { Video_name= "ms-appx:///videoTest.mp4" }, new video { Video_name = "ms-appx:///videoTest.mp4" },  new video { Video_name= "ms-appx:///videoTest.mp4" } },
            new List<video>  {new video { Video_name= "ms-appx:///videoTest.mp4" } },
            new List<video> {},
            new List<video> {},

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
        internal int[] PostInfoType = new int[] {
        1,
        0,
        3,
        4,
        2,
        2,
         1,
        0,
        3,
        4,
        2,
        2,
         1,
        0,
        3,
        4,
        2,
        2,
         1,
        0,
        3,
        4,
        2,
        2,
        0,
        1,
        3,
        4,
        2,
        2,
        };
        internal bool[] PostInfoLikeStatut = new bool[] {
            true,
            false,
            true,
            true,
            false,
            false,
            true,
            false,
            true,
            true,
            false,
            false,
            true,
            false,
            true,
            true,
            false,
            false,
            true,
            false,
            true,
            true,
            false,
            false,
            true,
            false,
            true,
            true,
            false,
            false,
        };  
        internal List<commentaire> PostInfoComment = new List<commentaire>
        {
            new commentaire
            {
                Comment= "Hahaha!!! vous les camerounais vous etes toujours comme ca..",
                Avatar= "leouche",
                NomUtilisateur="Mr Ketch",
                NbreJaime=2,
                Reponses= new List<reponse>
                {
                    
                },
            },
            new commentaire
            {
                Comment= "Demande la meme chose aux gens qui t'on amener ici\n les bizzares appres vous vous plsignes..",
                NbreJaime=1,
                 Avatar= "leouche",
                NomUtilisateur="Mr Ketch",
                Reponses= new List<reponse>
                {
                    new reponse{ Response="Maf",NbreJaimeReponse=0,NomUtilisateur="lelouche",Avatar="avatar.png" },
                    new reponse{Response="bIG lOL", NbreJaimeReponse=0,NomUtilisateur="zeuss",Avatar="avatar.png"},
                },
            },
            new commentaire
            {
                Comment= "Hahaha!!! vous les camerounais vous etes toujours comme ca..",
                NomUtilisateur="lelouche",Avatar="avatar.png",
                NbreJaime=2,
                Reponses= new List<reponse>
                {
                    new reponse{ Response="Maf",NbreJaimeReponse=0 ,NomUtilisateur="lelouche",Avatar="avatar.png"},
                },
            },
         
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
