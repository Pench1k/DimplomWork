namespace DAL.Models
{
    public class Motherboard // Материнская плата
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Computer>? Computers { get; set; }
    }
}
