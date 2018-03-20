using System.Collections.ObjectModel;
using System.Linq;
using Readit.ViewModel;
using RedditSharp;

namespace Readit.View
{
    public partial class PostView
    {
        public PostView()
        {
            InitializeComponent();
            PostListView.ItemsSource = Posts;
            UpdatePosts();
        }

        private static ObservableCollection<PostViewModel> Posts { get; set; }

        private static async void UpdatePosts()
        {
            await new Reddit().RSlashAll.GetPosts().Take(10).ForEachAsync(post =>
            {
                Posts.Add(new PostViewModel
                {
                    Title = post.Title,
                    Subreddit = post.SubredditName,
                    Author = post.AuthorName
                });
            });
        }
    }
}