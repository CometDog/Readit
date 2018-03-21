using System.Collections.ObjectModel;
using Readit.ViewModel;
using Xamarin.Forms;

namespace Readit.View
{
    public partial class PostView : ContentPage
    {
        private ObservableCollection<PostViewModel> Posts { get; set; }

        public PostView()
        {
            Posts = new ObservableCollection<PostViewModel>
            {
                new PostViewModel {Title = "Test1", Subreddit = "Test2", Author = "Test3"}
            };
            PostListView.ItemsSource = Posts;
        }
    }
}