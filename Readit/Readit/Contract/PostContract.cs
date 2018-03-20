using Readit.Model;

namespace Readit.Contract
{
    public abstract class PostContract
    {
        public interface IView
        {
            void AddPosts(FrontPageModel model);
        }

        public interface IPresenter
        {
            void UpdatePosts();
        }
    }
}