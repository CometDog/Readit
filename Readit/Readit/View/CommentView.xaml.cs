using System.Collections.ObjectModel;
using Readit.Contract;
using Readit.Model;
using Readit.Presenter;

namespace Readit.View
{
    public partial class CommentView : CommentContract.IView
    {
        private readonly CommentContract.IPresenter _presenter;

        public CommentView(string commentPermalink)
        {
            _presenter = new CommentPresenter(this);
            InitializeComponent();

            Comments = new ObservableCollection<CommentModel>();
            CommentListView.ItemsSource = Comments;
            _presenter.UpdateComments(commentPermalink);
        }

        private ObservableCollection<CommentModel> Comments { get; }

        public void AddComments(CommentsModel model)
        {
            foreach (var childrenModel in model.Data.Children) Comments.Add(childrenModel.Data);
        }
    }
}