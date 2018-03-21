using System;
using System.Linq;
using Readit.Contract;

namespace Readit.View
{
    public partial class SearchView
    {
        private readonly PostContract.IView _view;

        public SearchView(PostContract.IView view)
        {
            _view = view;
            InitializeComponent();
        }

        private async void Search(object sender, EventArgs e)
        {
            _view.RequestUpdate($"/r/{SubredditEntry.Text.Split('/').Last()}", true);
            await Navigation.PopAsync();
        }
    }
}