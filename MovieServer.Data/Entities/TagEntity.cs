namespace MovieServer.Data.Entities
{
    public record TagEntity : BaseEntity
    {
        public uint userId { get; set; }
        public uint movieId { get; set; }
        public string? tag { get; set; }
        public uint timestamp { get; set; }
    }
}
