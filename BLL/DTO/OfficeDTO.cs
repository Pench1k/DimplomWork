

namespace BLL.DTO
{
    public class OfficeDTO
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Body { get; set; }
        public int? DepartmentId { get; set; }   
        public int NumberOfAvailableSeats { get; set; }
    }
}
