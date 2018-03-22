using Readit.Contract;
using Readit.View;
using Xamarin.Forms;

namespace Readit.Navigator
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