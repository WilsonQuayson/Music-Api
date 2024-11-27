namespace ProjectApi.models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string DebutYear { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
    }
}
