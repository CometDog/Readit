using System.Collections.Generic;
using Newtonsoft.Json;

namespace Readit.Model
{
    public class SubredditModel
    {
        [JsonProperty(PropertyName = "data")]
        public ListingModel Data { get; set; }
    }

    public class ListingModel
    {
        [JsonProperty(PropertyName = "children")]
        public List<ChildrenModel> Children { get; set; }
    }

    public class ChildrenModel
    {
        [JsonProperty(PropertyName = "data")]
        public PostModel Data { get; set; }
    }

    public class PostModel
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "subreddit")]
        public string Subreddit { get; set; }

        [JsonProperty(PropertyName = "author")]
        public string Author { get; set; }

        [JsonProperty(PropertyName = "preview")]
        public PreviewModel Preview { get; set; }
    }

    public class PreviewModel
    {
        [JsonProperty(PropertyName = "images")]
        public List<ImagesModel> Images { get; set; }
    }

    public class ImagesModel
    {
        [JsonProperty(PropertyName = "source")]
        public ImageModel Source { get; set; }

        [JsonProperty(PropertyName = "resolutions")]
        public List<ImageModel> Resolutions { get; set; }
    }

    public class ImageModel
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "width")]
        public long Width { get; set; }

        [JsonProperty(PropertyName = "height")]
        public long Height { get; set; }
    }
}