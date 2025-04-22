namespace DAL.Models
{
    public class Processor // Процессор
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Computer>? Computers { get; set; }
    }
}
