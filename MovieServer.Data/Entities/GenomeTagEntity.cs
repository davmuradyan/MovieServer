namespace MovieServer.Data.Entities
{
    public record GenomeTagEntity : BaseEntity
    {
        public uint tagId { get; set; }
        public string? tag { get; set; }
    }
}
