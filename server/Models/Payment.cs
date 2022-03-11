namespace server.Models
{
    public class Payment
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Card { get; set; }
        public string? CVC { get; set; }
        public DateTime Expiry { get; set; }
    }
}