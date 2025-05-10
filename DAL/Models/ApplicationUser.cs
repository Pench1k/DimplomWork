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


        public List<ArrivalFromTheWarehouse>? ArrivalFromTheWarehouse { get; set; }
        public List<Coming>? Comings { get; set; }
        public List<ComputerPassport>? ComputerPassport { get; set; }

    }
}
