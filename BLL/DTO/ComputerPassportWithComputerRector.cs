using DAL.Models;

namespace BLL.DTO
{
    public class ComputerPassportWithComputerRector
    {
        public int Id { get; set; }
        public string? InventoryNumber { get; set; }

        public DateOnly? DateOfReceipt { get; set; }
        public DateOnly? DateOfDebit { get; set; }

        public ComputerPassportStatus computerPassportStatus { get; set; }


        public int? WarehouseId { get; set; }   
        public string? WarehouseName {  get; set; }


        public int? ComputerId { get; set; }

        public string? ProcessorName { get; set; }

        public string? MotherboardName { get; set; }

        public string? RamName { get; set; }

        public string? OcName { get; set; }

        public string? MemoryDiskName { get; set; }

        public string? PowerUnitName { get; set; }

        public string? VideoCardName { get; set; }

        public string? MouseName { get; set; }

        public string? KeyboardName { get; set; }

        public string? ScreenName { get; set; }

        public string? UserName { get; set; }
    }
}
