using Microsoft.AspNetCore.Identity;

namespace DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public int? WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }

        List<ArrivalFromTheWarehouse>? ArrivalFromTheWarehouse { get; set; }

    }
}
