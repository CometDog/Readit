using System;
using System.Linq;
using System.Threading.Tasks;

namespace Readit.View
{
    public partial class SearchView
    {
        private readonly TaskCompletionSource<string> _returnValue;

        public SearchView()
        {
            _returnValue = new TaskCompletionSource<string>();
            InitializeComponent();
        }

        public Task<string> PagePoppedTask => _returnValue.Task;

        private async void Search(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (SubredditEntry.Text != null && PagePoppedTask.IsCompleted == false)
                _returnValue.SetResult($"/r/{SubredditEntry.Text.Split('/').Last()}");
            else
                _returnValue.SetResult(null);
        }
    }
}