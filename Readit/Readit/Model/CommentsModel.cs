using System.Collections.Generic;
using Newtonsoft.Json;

namespace Readit.Model
{
    public class CommentsModel
    {
        [JsonProperty(PropertyName = "data")]
        public CommentListingModel Data { get; set; }
    }

    public class CommentListingModel
    {
        [JsonProperty(PropertyName = "children")]
        public List<CommentChildrenModel> Children { get; set; }
    }

    public class CommentChildrenModel
    {
        [JsonProperty(PropertyName = "kind")]
        public string Kind { get; set; }

        [JsonProperty(PropertyName = "data")]
        public CommentModel Data { get; set; }
    }

    public class CommentModel
    {
        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        [JsonProperty(PropertyName = "author")]
        public string Author { get; set; }

        [JsonProperty(PropertyName = "created_utc")]
        public string Created { get; set; }

        [JsonProperty(PropertyName = "replies")]
        public CommentsModel Replies { get; set; }
    }
}