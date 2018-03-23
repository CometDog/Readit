using System.Net.Http;
using Newtonsoft.Json;
using Readit.Contracts;
using Readit.Models;

namespace Readit.Presenters
{
    public class PostPresenter : PostContract.IPresenter
    {
        private readonly PostContract.IView _view;

        public PostPresenter(PostContract.IView view)
        {
            _view = view;
        }

        public async void UpdatePosts(string subreddit = "")
        {
            var json = await new HttpClient().GetStringAsync($"https://www.reddit.com{subreddit}/.json");
            var frontPage = JsonConvert.DeserializeObject<SubredditModel>(json);
            _view.AddPosts(frontPage);
        }
    }
}