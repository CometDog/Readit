using System;
using System.Linq;
using Xamarin.Forms;

namespace Readit.Views
{
    public partial class SearchView
    {
        public SearchView()
        {
            InitializeComponent();
        }

        private async void Search(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "UpdateSubreddit",
                SubredditEntry.Text != null ? $"/r/{SubredditEntry.Text.Split('/').Last()}" : null);
            await Navigation.PopAsync();
        }
    }
}