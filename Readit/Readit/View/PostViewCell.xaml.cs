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

            if (item.Preview == null) return;
            SetThumbnail(item);
        }

        private void SetTextViews(PostModel item)
        {
            Title.Text = item.Title;
            Subreddit.Text = item.Subreddit;
            Author.Text = item.Author;
        }

        private void SetThumbnail(PostModel item)
        {
            var image = item.Preview.Images.First();
            var thumbnail = image.Resolutions.First();
            var source = image.Source;
            var thumbnailUrl = thumbnail.Url.Replace("&amp;", "&");
            var sourceUrl = source.Url.Replace("&amp;", "&");

            Thumbnail.Source = thumbnailUrl;
            Thumbnail.WidthRequest = 100;
            Thumbnail.HeightRequest = 100;

            var gesture = new TapGestureRecognizer();
            gesture.Tapped += (sender, eventArgs) => { Device.OpenUri(new Uri(sourceUrl)); };
            Thumbnail.GestureRecognizers.Add(gesture);
        }
    }
}