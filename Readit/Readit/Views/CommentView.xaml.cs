using System.Collections.Generic;
using System.Collections.ObjectModel;
using Readit.Contracts;
using Readit.Models;
using Readit.Presenters;

namespace Readit.Views
{
    public partial class CommentView : CommentContract.IView
    {
        private readonly CommentContract.IPresenter _presenter;

        public CommentView(string commentPermalink)
        {
            _presenter = new CommentPresenter(this);
            InitializeComponent();

            Comments = new ObservableCollection<List<PostsCommentModel>>();
            CommentListView.ItemsSource = Comments;
            _presenter.UpdateComments(commentPermalink);
        }

        private ObservableCollection<List<PostsCommentModel>> Comments { get; }

        public void AddComments(List<PostsModel> models)
        {
            foreach (var model in models)
            {
                var commentList = new List<PostsCommentModel>();
                foreach (var childrenModel in model.Data.Children)
                    if (childrenModel.Kind == "t1")
                        commentList.Add(childrenModel.Data);

                if (commentList.Count > 0) Comments.Add(commentList);
            }
        }
    }
}