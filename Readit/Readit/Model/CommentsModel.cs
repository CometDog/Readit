using System.Collections.Generic;
using Newtonsoft.Json;

namespace Readit.Model
{
    [JsonArray]
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
    }
}