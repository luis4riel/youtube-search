
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System.Text.Json;
using YoutubeSearch.Application.Interfaces;
using YoutubeSearch.Domain.Models;
using YoutubeSearch.Persistence.Interfaces;

namespace YoutubeSearch.Application.Services
{
    public class YoutubeSearchService : IYoutubeSearchService
    {
        private readonly IBaseRepository BaseRepository;
        public YoutubeSearchService(IBaseRepository baseRepository)
        {
            BaseRepository = baseRepository;
        }

        public async Task<bool> Add(SearchResult searchResult)
        {
            try
            {
                BaseRepository.Add(searchResult);
                if (await BaseRepository.SaveChangesAsync())
                    return true;
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Delete(Guid guid)
        {
            try
            {
                var result = BaseRepository.GetSearchResultById(guid).Result;
                if (result == null) throw new Exception("Elemento não ecxiste...");

                BaseRepository.Delete(result);
                return await BaseRepository.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<SearchResult[]> GetAllSearchResultsAsync()
        {
            try
            {
                return BaseRepository.GetAllSearchResultsAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<SearchResult[]> GetSearchResults(string valueContent)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyDzv8vVaC2xdP1K8B6rJJD7IdO0W9O4hH8",
                ApplicationName = GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = valueContent;
            searchListRequest.MaxResults = 50;

            var searchListResponse = await searchListRequest.ExecuteAsync();

            List<SearchResult> Results = new();
            foreach (var item in searchListResponse.Items)
            {
                Results.Add(MakeNewSearchResult(item));
            }
            youtubeService.Dispose();

            return Results.ToArray();
        }

        public string SearchContent(string valueContent)
        {
            var response = GetSearchResults(valueContent.Replace(" ", ",").Trim().TrimEnd().TrimStart()).Result;

            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(response, options);
        }

        private SearchResult MakeNewSearchResult(Google.Apis.YouTube.v3.Data.SearchResult item)
        {
            return new(
                item.ETag,
                new ResourceId()
                {
                    ChannelId = item.Id.ChannelId,
                    ETag = item.Id.ETag,
                    Kind = item.Id.Kind,
                    PlaylistId = item.Id.PlaylistId,
                    VideoId = item.Id.VideoId
                },
                item.Kind,
                new Snippet()
                {
                    ChannelId = item.Snippet.ChannelId,
                    ChannelTitle = item.Snippet.ChannelTitle,
                    ETag = item.Snippet.ETag,
                    Description = item.Snippet.Description,
                    LiveBroadcastContent = item.Snippet.LiveBroadcastContent,
                    PublishedAt = item.Snippet.PublishedAt,
                    PublishedAtRaw = item.Snippet.PublishedAtRaw,
                    Title = item.Snippet.Title,
                });
        }
    }
}