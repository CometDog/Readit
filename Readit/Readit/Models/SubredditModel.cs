using System.Collections.Generic;
using Newtonsoft.Json;

namespace Readit.Models
{
    public class SubredditModel
    {
        [JsonProperty(PropertyName = "data")]
        public SubredditListingModel Data { get; set; }
    }

    public class SubredditListingModel
    {
        [JsonProperty(PropertyName = "children")]
        public List<SubredditChildrenModel> Children { get; set; }
    }

    public class SubredditChildrenModel
    {
        [JsonProperty(PropertyName = "data")]
        public SubredditPostModel Data { get; set; }
    }

    public class SubredditPostModel
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "subreddit")]
        public string Subreddit { get; set; }

        [JsonProperty(PropertyName = "author")]
        public string Author { get; set; }

        [JsonProperty(PropertyName = "permalink")]
        public string Permalink { get; set; }

        [JsonProperty(PropertyName = "thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "is_self")]
        public bool Self { get; set; }

        [JsonProperty(PropertyName = "preview")]
        public SubredditPreviewModel Preview { get; set; }
    }

    public class SubredditPreviewModel
    {
        [JsonProperty(PropertyName = "images")]
        public List<SubredditImagesModel> Images { get; set; }
    }

    public class SubredditImagesModel
    {
        [JsonProperty(PropertyName = "source")]
        public SubredditImageModel Source { get; set; }

        [JsonProperty(PropertyName = "resolutions")]
        public List<SubredditImageModel> Resolutions { get; set; }
    }

    public class SubredditImageModel
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "width")]
        public long Width { get; set; }

        [JsonProperty(PropertyName = "height")]
        public long Height { get; set; }
    }
}