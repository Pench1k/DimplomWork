namespace DAL.Models
{
    public class ComputerPassport
    {
        public int Id { get; set; }

        public int InventoryNumber { get; set; }

        public int? ComputerId { get; set; }
        public Computer? Computer { get; set; }

        public DateOnly DateOfReceipt {  get; set; }
        public DateOnly DateOfDebit { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public int? OfficeId {  get; set; }
        public Office? Office { get; set; }

        public int? WarehouseId {  get; set; }
        public Warehouse? Warehouse { get; set; }
    }
}
