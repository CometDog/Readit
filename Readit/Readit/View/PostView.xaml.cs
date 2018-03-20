using System.Collections.Generic;
using System.Collections.ObjectModel;
using Readit.ViewModel;
using Xamarin.Forms;

namespace Readit.View
{
    public partial class PostView : ContentPage
    {
        public PostView()
        {
            InitializeComponent();
            PostListView.ItemsSource = GetPosts();
        }

        private static IEnumerable<PostViewModel> GetPosts()
        {
            return new ObservableCollection<PostViewModel>
            {
                new PostViewModel {Title = "Test1", Subreddit = "Test2", Author = "Test3"}
            };
        }
    }
}