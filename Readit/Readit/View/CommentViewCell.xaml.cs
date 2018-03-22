using System;
using System.Globalization;
using Readit.Model;

namespace Readit.View
{
    public partial class CommentViewCell
    {
        public CommentViewCell()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (!(BindingContext is CommentModel item)) return;
            SetTextViews(item);
        }

        private void SetTextViews(CommentModel item)
        {
            Author.Text = item.Author;
            TimeSincePost.Text =
                (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(double.Parse(item.Created))
                     .ToLocalTime()).TotalDays.ToString(CultureInfo.CurrentCulture);
            Comment.Text = item.Author;
        }
    }
}