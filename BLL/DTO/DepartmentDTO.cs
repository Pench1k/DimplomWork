

namespace BLL.DTO
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int? DeanOfficeId { get; set; }

        public string? DeanOfficeName { get; set; }
    }

    public class DepartmentCreate
    {
        public string? Name { get; set; }    
        public int? DeanOfficeId { get; set; }
    }

    public class DepartmentCreateDto
    {
        public string Name { get; set; }
        public int? DeanOfficeId { get; set; }
    }

}
