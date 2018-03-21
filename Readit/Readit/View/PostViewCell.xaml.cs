using System;
using System.Linq;
using Readit.Model;
using Xamarin.Forms;

namespace Readit.View
{
    public partial class PostViewCell
    {
        public PostViewCell()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (!(BindingContext is PostModel item)) return;
            SetTextViews(item);
            if (item.Preview != null || item.Url != null && !item.Url.Contains("reddit.com")) SetThumbnail(item);
        }

        private void SetTextViews(PostModel item)
        {
            Title.Text = item.Title;
            Subreddit.Text = item.Subreddit;
            Author.Text = item.Author;
        }

        private void SetThumbnail(PostModel item)
        {
            string url;
            if (item.Preview != null)
            {
                var image = item.Preview.Images.First();
                var thumbnail = image.Resolutions.First();
                var source = image.Source;

                var thumbnailUrl = thumbnail.Url.Replace("&amp;", "&");
                url = source.Url.Replace("&amp;", "&");

                Thumbnail.Source = ImageSource.FromUri(new Uri(thumbnailUrl));
            }
            else if (item.Url != null)
            {
                url = item.Url;
                Thumbnail.Source = ImageSource.FromResource("Readit.Resources.Images.icon_link.png");
            }
            else
            {
                return;
            }

            Thumbnail.IsVisible = true;

            var gesture = new TapGestureRecognizer();
            gesture.Tapped += (sender, eventArgs) => { Device.OpenUri(new Uri(url)); };
            Thumbnail.GestureRecognizers.Add(gesture);
        }
    }
}