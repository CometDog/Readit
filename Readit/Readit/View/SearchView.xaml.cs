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
            SetReturnValue(SubredditEntry.Text);
            await Navigation.PopAsync();
        }

        private void SetReturnValue(string text)
        {
            if (text != null && PagePoppedTask.IsCompleted == false)
                _returnValue.SetResult($"/r/{text.Split('/').Last()}");
            else
                _returnValue.SetResult(null);
        }
    }
}