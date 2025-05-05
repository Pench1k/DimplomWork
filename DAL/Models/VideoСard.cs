namespace DAL.Models
{
    public class VideoСard // Видеокарта
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Computer>? Computers { get; set; }
    }
}
