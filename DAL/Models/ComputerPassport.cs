using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class ComputerPassport
    {
        public int Id { get; set; }

        public string? InventoryNumber { get; set; }

        public int? ComputerId { get; set; }
        public Computer? Computer { get; set; }

        public DateOnly? DateOfReceipt {  get; set; }
        public DateOnly? DateOfDebit { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public int? OfficeId {  get; set; }
        public Office? Office { get; set; }

        public int? WarehouseId {  get; set; }
        public Warehouse? Warehouse { get; set; }    

        public ComputerPassportStatus computerPassportStatus { get; set; }

        public List<RepairComputer>? RepairComputers { get; set; }

    }

    public enum ComputerPassportStatus
    {
        [Display(Name = "Готов к распределению")]
        ReadyForDistribution,

        [Display(Name = "Распределен")]
        Arrival,

        [Display(Name = "В работе")]
        Work,

        [Display(Name = "В ремонте")]
        UnderRenovation
    }
}

