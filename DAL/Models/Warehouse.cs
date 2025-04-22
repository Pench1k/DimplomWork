namespace DAL.Models
{
    public class Warehouse // Склад
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Computer>? Computers { get; set; }
    }
}
