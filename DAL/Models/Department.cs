namespace DAL.Models
{
    public class Department // Кафедра
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? DeanOfficeId { get; set; }
        public DeanOffice? DeanOffice { get; set; }
    }
}
