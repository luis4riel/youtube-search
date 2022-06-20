using Microsoft.EntityFrameworkCore;
using YoutubeSearch.Domain.Models;
using YoutubeSearch.Persistence.Interfaces;

namespace YoutubeSearch.Persistence
{
    public class BaseRepository : IBaseRepository
    {
        private readonly DataContext _context;

        public BaseRepository(DataContext dataContext)
        {
            _context = dataContext;
            _context.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
            _context.RemoveRange(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<SearchResult[]> GetAllSearchResultsAsync()
        {
            IQueryable<SearchResult> query = _context.SearchResults
                .Include(e => e.Snippet)
                .Include(e => e.ResourceId);

            return await query.ToArrayAsync();
        }

        public async Task<SearchResult> GetSearchResultByEtag(string etag)
        {
            IQueryable<SearchResult> query = _context.SearchResults
                .Include(e => e.Snippet)
                .Include(e => e.ResourceId);

            query = query.Where(e => e.ETag.Equals(etag));

            return await query.FirstOrDefaultAsync();
        }
    }
}
