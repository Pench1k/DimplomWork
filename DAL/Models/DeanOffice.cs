namespace DAL.Models
{
    public class DeanOffice // Деканат
    {
        public int Id { get; set; } 
        public string? Name { get; set; }

        public List<Department>? Departments { get; set; }
    }
}
