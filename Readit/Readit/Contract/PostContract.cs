using Readit.Model;

namespace Readit.Contract
{
    public abstract class PostContract
    {
        public interface IView
        {
            void RequestUpdate(string subreddit, bool clearList = false);
            void AddPosts(SubredditModel model);
        }

        public interface IPresenter
        {
            void UpdatePosts(string subreddit = "");
        }
    }
}