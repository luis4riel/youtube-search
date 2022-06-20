using YoutubeSearch.Domain.Models;

namespace YoutubeSearch.Application.Interfaces
{
    public interface IYoutubeSearchService
    {
        public Task<bool> Add(SearchResult searchResult);
        public Task<bool> Delete(string etag);
        public Task<SearchResult[]> GetAllSearchResultsAsync();
        public string SearchContent(string valueContent);
        public Task<SearchResult[]> GetSearchResults(string valueContent);
    }
}
