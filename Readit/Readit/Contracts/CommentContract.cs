using System.Collections.Generic;
using Readit.Model;

namespace Readit.Contract
{
    public abstract class CommentContract
    {
        public interface IView
        {
            void AddComments(List<PostsModel> models);
        }

        public interface IPresenter
        {
            void UpdateComments(string commentPermalink);
        }
    }
}