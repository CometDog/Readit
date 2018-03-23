using Readit.Models;

namespace Readit.Contracts
{
    public abstract class PostContract
    {
        public interface IView
        {
            void AddPosts(SubredditModel model);
        }

        public interface IPresenter
        {
            void UpdatePosts(string subreddit);
        }

        public interface INavigator
        {
            void ShowSearchScreen();
            void ShowCommentScreen(string commentPermalink);
        }
    }
}