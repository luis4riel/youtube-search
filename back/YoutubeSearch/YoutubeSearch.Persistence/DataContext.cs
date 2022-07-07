using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using YoutubeSearch.Domain.Models;

namespace YoutubeSearch.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<SearchResult> SearchResults { get; set; }
        public DbSet<ResourceId> ResourceIds { get; set; }
        public DbSet<Snippet> Snippets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SearchResult>()
                .HasKey(SR => SR.Id);
                        
            modelBuilder.Entity<ResourceId>()
                .HasKey(Res => Res.Id);

            modelBuilder.Entity<Snippet>()
                .HasKey(Snip => Snip.Id);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("AppDb");
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
