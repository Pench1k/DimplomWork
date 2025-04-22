namespace DAL.Models
{
    public class MemoryDisk // Жесткий диск
    {
        public int Id 
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }

        public List<Computer>? Computers { get; set; }
    }
}
