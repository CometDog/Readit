using System.Collections.ObjectModel;
using Readit.Contracts;
using Readit.Models;
using Readit.Navigators;
using Readit.Presenters;
using Xamarin.Forms;

namespace Readit.Views
{
    public partial class PostView : PostContract.IView
    {
        private readonly PostContract.INavigator _navigator;
        private readonly PostContract.IPresenter _presenter;

        public PostView()
        {
            _presenter = new PostPresenter(this);
            _navigator = new PostNavigator(this);

            SubscribeToMessages();
            InitializeComponent();

            SearchItem.Clicked += (sender, args) => _navigator.ShowSearchScreen();

            Posts = new ObservableCollection<SubredditPostModel>();
            PostListView.ItemsSource = Posts;
            RequestUpdate();
        }

        private ObservableCollection<SubredditPostModel> Posts { get; }

        public void AddPosts(SubredditModel model)
        {
            foreach (var childrenModel in model.Data.Children) Posts.Add(childrenModel.Data);
        }

        private void SubscribeToMessages()
        {
            MessagingCenter.Subscribe<PostViewCell, string>(this, "PostClicked", (sender, arg) =>
            {
                if (arg != null) _navigator.ShowCommentScreen(arg);
            });

            MessagingCenter.Subscribe<SearchView, string>(this, "UpdateSubreddit", (sender, arg) =>
            {
                if (arg != null) RequestUpdate(arg, true);
            });
        }

        private void RequestUpdate(string subreddit = "", bool clearList = false)
        {
            SetTitle(subreddit);
            if (clearList) Posts.Clear();
            _presenter.UpdatePosts(subreddit);
        }

        private void SetTitle(string title)
        {
            if (title == "") title = "Front Page";
            Title = title;
        }
    }
}