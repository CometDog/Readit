using System;
using System.Collections.Generic;
using System.Globalization;
using Readit.Model;
using Xamarin.Forms;

namespace Readit.View
{
    public partial class CommentStackLayout
    {
        public CommentStackLayout()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (!(BindingContext is List<CommentModel> items)) return;
            foreach (var item in items) AddViews(item);
        }

        private void AddViews(CommentModel item)
        {
            Children.Add(BuildView(item));
            if (item.Replies == null) return;
            foreach (var reply in item.Replies.Data.Children) AddViews(reply.Data);
        }

        private StackLayout BuildView(CommentModel item)
        {
            var verticalStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(16, 8)
            };

            var horizontalStackLayout = new StackLayout {Orientation = StackOrientation.Horizontal};

            var authorLabel = new Label
            {
                FontSize = 12,
                LineBreakMode = LineBreakMode.TailTruncation,
                Text = item.Author
            };

            var timeSincePostLabel = new Label
            {
                FontSize = 12,
                LineBreakMode = LineBreakMode.TailTruncation,
                Text = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(double.Parse(item.Created))
                            .ToLocalTime()).TotalDays.ToString(CultureInfo.CurrentCulture)
            };

            horizontalStackLayout.Children.Add(authorLabel);
            horizontalStackLayout.Children.Add(timeSincePostLabel);

            verticalStackLayout.Children.Add(horizontalStackLayout);

            var commentLabel = new Label
            {
                FontSize = 16,
                Text = item.Body
            };

            verticalStackLayout.Children.Add(commentLabel);

            return verticalStackLayout;
        }
    }
}