﻿using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Readit.Contract;
using Readit.Model;

namespace Readit.Presenter
{
    public class CommentPresenter : CommentContract.IPresenter
    {
        private readonly CommentContract.IView _view;

        public CommentPresenter(CommentContract.IView view)
        {
            _view = view;
        }

        public async void UpdateComments(string commentPermalink)
        {
            var json = await new HttpClient().GetStringAsync($"https://www.reddit.com{commentPermalink}/.json");
            var comments = JsonConvert.DeserializeObject<List<CommentsModel>>(json);
            _view.AddComments(comments);
        }
    }
}