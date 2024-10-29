using Microsoft.EntityFrameworkCore;
using MovieServer.Data.Entities;

namespace MovieServer.Data.DAO {
    public class MainDbContext : DbContext {
        public MainDbContext(DbContextOptions options) : base(options) { }
        public DbSet<LinkEntity> Links { get; set; }
        public DbSet<GenomeScoreEntity> GenomeScores { get; set; }
        public DbSet<GenomeTagEntity> GenomeTags { get; set; }
        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<RatingEntity> Ratings { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
    }
}
    