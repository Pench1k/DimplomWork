namespace DAL.Models
{
    public class Keyboard // Клавиатура
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
