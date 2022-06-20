using YoutubeSearch.Domain.Models;

namespace YoutubeSearch.Persistence.Interfaces
{
    public interface IBaseRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<SearchResult[]> GetAllSearchResultsAsync();
        Task<SearchResult> GetSearchResultById(Guid guid);
    }
}
