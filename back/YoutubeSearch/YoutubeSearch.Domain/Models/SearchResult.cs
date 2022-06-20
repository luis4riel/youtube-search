using Newtonsoft.Json;

namespace YoutubeSearch.Domain.Models
{
    public class SearchResult
    {
        public Guid Id = Guid.NewGuid();

        [JsonProperty("etag")]
        public virtual string? ETag { get; set; }

        [JsonProperty("id")]
        public virtual ResourceId? ResourceId { get; set; }

        [JsonProperty("kind")]
        public virtual string? Kind { get; set; }

        [JsonProperty("snippet")]
        public virtual Snippet? Snippet { get; set; }

        public SearchResult() { }
        public SearchResult(string eTag, ResourceId resourceId, string kind, Snippet snippet)
        {
            Id = Guid.NewGuid();
            ETag = eTag;
            Kind = kind;
            ResourceId = resourceId;
            Snippet = snippet;
        }
    }
}
