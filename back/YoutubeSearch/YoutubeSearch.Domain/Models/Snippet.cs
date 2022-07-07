using Google.Apis.Util;
using Newtonsoft.Json;

namespace YoutubeSearch.Domain.Models
{
    public class Snippet
    {
        public Guid Id = Guid.NewGuid();

        [JsonProperty("channelId")]
        public virtual string? ChannelId { get; set; }

        [JsonProperty("channelTitle")]
        public virtual string? ChannelTitle { get; set; }

        [JsonProperty("description")]
        public virtual string? Description { get; set; }

        [JsonProperty("liveBroadcastContent")]
        public virtual string? LiveBroadcastContent { get; set; }

        [JsonProperty("publishedAt")]
        public virtual string? PublishedAtRaw { get; set; }

        [JsonIgnore]
        public virtual DateTime? PublishedAt
        {
            get
            {
                return Utilities.GetDateTimeFromString(PublishedAtRaw);
            }
            set
            {
                PublishedAtRaw = Utilities.GetStringFromDateTime(value);
            }
        }

        [JsonProperty("title")]
        public virtual string? Title { get; set; }
        public virtual string? ETag { get; set; }
    }
}
