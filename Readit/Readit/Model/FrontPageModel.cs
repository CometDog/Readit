using System.Collections.Generic;
using Newtonsoft.Json;

namespace Readit.Model
{
    public class FrontPageModel
    {
        [JsonProperty(PropertyName = "data")] public ListingModel Data { get; set; }
    }

    public class ListingModel
    {
        [JsonProperty(PropertyName = "children")]
        public List<ChildrenModel> Children { get; set; }
    }

    public class ChildrenModel
    {
        [JsonProperty(PropertyName = "data")] public PostModel Data { get; set; }
    }

    public class PostModel
    {
        [JsonProperty(PropertyName = "title")] public string Title { get; set; }

        [JsonProperty(PropertyName = "subreddit")]
        public string Subreddit { get; set; }

        [JsonProperty(PropertyName = "author")]
        public string Author { get; set; }
    }
}