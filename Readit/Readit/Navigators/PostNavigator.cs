using Readit.Contracts;
using Readit.Views;
using Xamarin.Forms;

namespace Readit.Navigators
{
    public class PostNavigator : PostContract.INavigator
    {
        private readonly PostContract.IView _view;

        public PostNavigator(PostContract.IView view)
        {
            _view = view;
        }

        public async void ShowSearchScreen()
        {
            var searchView = new SearchView();
            await Application.Current.MainPage.Navigation.PushAsync(searchView);
        }

        public async void ShowCommentScreen(string commentPermalink)
        {
            var commentView = new CommentView(commentPermalink);
            await Application.Current.MainPage.Navigation.PushAsync(commentView);
        }
    }
}