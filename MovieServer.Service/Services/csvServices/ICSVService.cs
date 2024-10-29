using MovieServer.Data.Entities;

namespace MovieServer.Core.Services.csvServices {
    public interface ICSVService {
        public void AddGenomeScoreEntity();
        public void AddRatingEntity(int part);
        
    }
}
