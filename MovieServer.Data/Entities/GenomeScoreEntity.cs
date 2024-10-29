namespace MovieServer.Data.Entities
{
    public record GenomeScoreEntity : BaseEntity
    {
        public uint? movieId { get; set; }
        public uint? tagId { get; set; }
        public double? relevance { get; set; }
    }
}
