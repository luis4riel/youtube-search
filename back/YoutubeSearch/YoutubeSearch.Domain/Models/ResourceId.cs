using Newtonsoft.Json;

namespace YoutubeSearch.Domain.Models
{
    public class ResourceId
    {
        public Guid Id = Guid.NewGuid();

        [JsonProperty("channelId")]
        public virtual string? ChannelId { get; set; }

        [JsonProperty("kind")]
        public virtual string? Kind { get; set; }

        [JsonProperty("playlistId")]
        public virtual string? PlaylistId { get; set; }

        [JsonProperty("videoId")]
        public virtual string? VideoId { get; set; }

        public virtual string? ETag { get; set; }
    }
}
