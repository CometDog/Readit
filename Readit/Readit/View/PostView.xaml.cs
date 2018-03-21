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
            _presenter.UpdatePosts("/r/mechanicalkeyboards");
            SetTitle("/r/mechanicalkeyboards");
        }

        private ObservableCollection<PostModel> Posts { get; }

        public void AddPosts(SubredditModel model)
        {
            foreach (var childrenModel in model.Data.Children) Posts.Add(childrenModel.Data);
        }

        private void SetTitle(string title)
        {
            Title = title;
        }
    }
}