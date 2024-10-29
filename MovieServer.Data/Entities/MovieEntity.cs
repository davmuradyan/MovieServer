namespace MovieServer.Data.Entities
{
    public record MovieEntity : BaseEntity
    {
        public uint movieId { get; set; }
        public string? title { get; set; }
        public string? genres { get; set; }
    }
}
