namespace DAL.Models
{
    public class RAM // Оперативная память
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Computer>? Computers { get; set; }

    }
}
