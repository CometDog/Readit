using System.Collections.ObjectModel;
using Readit.Contract;
using Readit.Model;
using Readit.Presenter;

namespace Readit.View
{
    public partial class PostView : PostContract.IView
    {
        private readonly PostPresenter _presenter;

        public PostView()
        {
            _presenter = new PostPresenter(this);
            InitializeComponent();
            PostListView.ItemsSource = Posts;
            _presenter.UpdatePosts();
        }

        public ObservableCollection<PostModel> Posts { get; set; }
    }
}