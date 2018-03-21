using Readit.Model;

namespace Readit.Contract
{
    public abstract class PostContract
    {
        public interface IView
        {
            void AddPosts(SubredditModel model);
        }

        public interface IPresenter
        {
            void UpdatePosts(string subreddit = "");
        }
    }
}