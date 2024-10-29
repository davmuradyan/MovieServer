using MovieServer.Data.Entities;
using MovieServer.Data.DAO;
using Microsoft.EntityFrameworkCore;

namespace MovieServer.Core.Services.csvServices {
    public class AddData : ICSVService {
        MainDbContext _context;

        public AddData(MainDbContext context) {
            _context = context;
        }

        public void AddGenomeScoreEntity() {
            var data = CsvReader.ReadGenomeScores().Skip(8700000);
            int batchSize = 100000; // Experiment with different batch sizes
            GenomeScoreEntity[] arr = new GenomeScoreEntity[batchSize];
            int i = 0;
            int dataNum = 0;

            _context.ChangeTracker.AutoDetectChangesEnabled = false; // Disable change tracking
            _context.Database.SetCommandTimeout(600); // 10 minutes

            foreach (var link in data) {
                if (link.Item1 == null || link.Item2 == null || link.Item3 == null) {
                    Console.WriteLine("Skipping null entry.");
                    continue; // Skip if any of the values are null
                }

                var item = new GenomeScoreEntity {
                    movieId = link.Item1.Value,
                    tagId = link.Item2.Value,
                    relevance = link.Item3.Value
                };

                arr[i] = item;
                i++;

                if (i == batchSize) {
                    _context.GenomeScores.AddRange(arr);
                    _context.SaveChanges();
                    arr = new GenomeScoreEntity[batchSize]; // Clear array
                    i = 0; // Reset counter
                    dataNum += batchSize;
                    Console.WriteLine($"Inserted batch of {batchSize}. Total inserted: {dataNum}.");
                }
            }

            // Insert remaining items if any
            if (i > 0) {
                var remaining = arr.Take(i).ToArray();
                _context.GenomeScores.AddRange(remaining);
                _context.SaveChanges();
                dataNum += remaining.Length;
                Console.WriteLine($"Inserted remaining batch of {remaining.Length}. Total inserted: {dataNum}.");
            }

            Console.WriteLine($"Total data inserted: {dataNum}.");
            _context.ChangeTracker.AutoDetectChangesEnabled = true; // Re-enable change tracking
        }
        public void AddRatingEntity(int part) {
            var data = CsvReader.ReadRatings(part);
            int batchSize = 100000; // Experiment with different batch sizes
            RatingEntity[] arr = new RatingEntity[batchSize];
            int i = 0;
            int dataNum = 0;

            _context.ChangeTracker.AutoDetectChangesEnabled = false; // Disable change tracking
            _context.Database.SetCommandTimeout(600); // 10 minutes

            foreach (var link in data) {
                var item = new RatingEntity {
                    userId = link.Item1.Value,
                    movieId = link.Item2.Value,
                    rating = link.Item3.Value,
                    timestamp = link.Item4.Value,
                };

                arr[i] = item;
                i++;

                if (i == batchSize) {
                    _context.Ratings.AddRange(arr);
                    _context.SaveChanges();
                    arr = new RatingEntity[batchSize]; // Clear array
                    i = 0; // Reset counter
                }
            }

            // Insert remaining items if any
            if (i > 0) {
                var remaining = arr.Take(i).ToArray();
                _context.Ratings.AddRange(remaining);
                _context.SaveChanges();
                dataNum += remaining.Length;
                Console.WriteLine($"Inserted remaining batch of {remaining.Length}. Total inserted: {dataNum}.");
            }

            Console.WriteLine($"Total data inserted: {dataNum}.");
            _context.ChangeTracker.AutoDetectChangesEnabled = true; // Re-enable change tracking
        }
    }
}
