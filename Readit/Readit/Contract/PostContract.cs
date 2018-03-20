using System.Collections.ObjectModel;
using Readit.Model;

namespace Readit.Contract
{
    public abstract class PostContract
    {
        public interface IView
        {
            ObservableCollection<PostModel> Posts { get; set; }
        }

        public interface IPresenter
        {
            void UpdatePosts();
        }
    }
}