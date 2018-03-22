using System.Collections.Generic;
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

            Comments = new ObservableCollection<List<CommentModel>>();
            CommentListView.ItemsSource = Comments;
            _presenter.UpdateComments(commentPermalink);
        }

        private ObservableCollection<List<CommentModel>> Comments { get; }

        public void AddComments(List<CommentsModel> models)
        {
            foreach (var model in models)
            {
                var commentList = new List<CommentModel>();
                foreach (var childrenModel in model.Data.Children)
                    if (childrenModel.Kind == "t1")
                        commentList.Add(childrenModel.Data);

                if (commentList.Count > 0) Comments.Add(commentList);
            }
        }
    }
}