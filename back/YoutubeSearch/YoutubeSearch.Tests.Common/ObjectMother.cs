using YoutubeSearch.Domain.Models;

namespace YoutubeSearch.Tests.Common
{
    public static class ObjectMother
    {
        public static SearchResult GetFakeSearchResult()
        {
            return new SearchResult()
            {
                ETag = "Test_ETag",
                Id = Guid.NewGuid(),
                Kind = "Test_Kind",
                ResourceId = new ResourceId()
                {
                    Id = Guid.NewGuid(),
                    ChannelId = "Test_ChannelId",
                    ETag = "Test_Etag",
                    Kind = "Test_kind",
                    PlaylistId = "Test_Playlist",
                    VideoId = "Test_VideoId",
                },
                Snippet = new Snippet()
                {
                    Id = Guid.NewGuid(),
                    ETag = "Test_Etag",
                    ChannelId = "Test_ChannelId",
                    ChannelTitle = "Test_ChannelTitle",
                    Description = "Test_Description",
                    LiveBroadcastContent = "Test_Livee",
                    PublishedAt = DateTime.Now,
                    PublishedAtRaw = "Test_PublishAtRaw",
                    Title = "Test_Title"
                },
            };
        }

        public static SearchResult[] GetAllResults()
        {
            List<SearchResult> searchResults = new()
            {
                GetFakeSearchResult(),
                GetFakeSearchResult()
            };
            return searchResults.ToArray();
        }
    }
}