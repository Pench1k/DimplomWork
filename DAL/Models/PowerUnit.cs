
namespace DAL.Models
{
    public class PowerUnit // Блок питания
    {
        public int Id
        {
            get; set;
        }
        public string? Name
        {
            get; set;
        }

        public List<Computer>? Computers { get; set; }
    }
}
