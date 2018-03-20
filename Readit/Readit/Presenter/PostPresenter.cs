using System.Net.Http;
using Newtonsoft.Json;
using Readit.Contract;
using Readit.Model;
using Readit.View;

namespace Readit.Presenter
{
    public class PostPresenter : PostContract.IPresenter
    {
        private readonly PostContract.IView _view;

        public PostPresenter(PostView view)
        {
            _view = view;
        }

        public async void UpdatePosts()
        {
            var json = await new HttpClient().GetStringAsync("https://www.reddit.com/.json");
            var frontPage = JsonConvert.DeserializeObject<FrontPageModel>(json);
            foreach (var childrenModel in frontPage.Data.Children) _view.Posts.Add(childrenModel.Data);
        }
    }
}