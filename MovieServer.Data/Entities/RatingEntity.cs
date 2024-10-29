namespace MovieServer.Data.Entities
{
    public record RatingEntity : BaseEntity
    {
        public uint? userId { get; set; }
        public uint? movieId { get; set; }
        public float? rating { get; set; }
        public uint? timestamp { get; set; }
    }
}
