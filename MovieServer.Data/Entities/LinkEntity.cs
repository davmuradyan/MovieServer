namespace MovieServer.Data.Entities
{
    public record LinkEntity : BaseEntity
    {
        public uint? movieId { get; set; }
        public uint? imdbId { get; set; }
        public uint? tmdbId { get; set; }
    }
}
