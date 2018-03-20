using Readit.ViewModel;
using Xamarin.Forms;

namespace Readit.View
{
    public partial class PostViewCell : ViewCell
    {
        public PostViewCell()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (!(BindingContext is PostViewModel item)) return;
            Title.Text = item.Title;
            Subreddit.Text = item.Subreddit;
            Author.Text = item.Author;
        }
    }
}