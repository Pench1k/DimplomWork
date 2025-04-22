namespace DAL.Models
{
    public class Workers
    {
        public int Id { get; set; }

        public string? ApplicationUserId {  get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public int? WarehouseId {  get; set; }
        public Warehouse? Warehouse { get; set; }
    }
}
