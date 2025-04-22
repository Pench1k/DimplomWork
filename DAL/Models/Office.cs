

namespace DAL.Models
{
    public class Office
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Body {  get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public int NumberOfAvailableSeats { get; set; }
    }
}
