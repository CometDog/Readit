using System;
using System.Collections.ObjectModel;
using Readit.Contract;
using Readit.Model;
using Readit.Presenter;

namespace Readit.View
{
    public partial class PostView : PostContract.IView
    {
        private readonly PostContract.IPresenter _presenter;

        public PostView()
        {
            _presenter = new PostPresenter(this);
            InitializeComponent();

            Posts = new ObservableCollection<PostModel>();
            PostListView.ItemsSource = Posts;
            RequestUpdate("");
        }

        private ObservableCollection<PostModel> Posts { get; }

        public void AddPosts(SubredditModel model)
        {
            foreach (var childrenModel in model.Data.Children) Posts.Add(childrenModel.Data);
        }

        private void RequestUpdate(string subreddit, bool clearList = false)
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

        private async void ShowSearchScreen(object sender, EventArgs e)
        {
            var searchView = new SearchView();
            await Navigation.PushAsync(searchView);
            var subreddit = await searchView.PagePoppedTask;
            if (subreddit != null) RequestUpdate(subreddit, true);
        }
    }
}