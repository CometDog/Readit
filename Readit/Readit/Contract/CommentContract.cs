using Readit.Model;

namespace Readit.Contract
{
    public abstract class CommentContract
    {
        public interface IView
        {
            void AddComments(CommentsModel model);
        }

        public interface IPresenter
        {
            void UpdateComments(string commentPermalink);
        }
    }
}