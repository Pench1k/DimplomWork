using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ComputerPassportWithComputerWarehouse
    {
        public int Id { get; set; }
        public string? InventoryNumber { get; set; }

        public DateOnly? DateOfReceipt { get; set; }
        public DateOnly? DateOfDebit { get; set; }

        public ComputerPassportStatus computerPassportStatus { get; set; }

        public int? ComputerId { get; set; }
      
        public string? ProcessorName { get; set; }

        public string? MotherboardName { get; set; }

        public string? RamName { get; set; }

        public string? OcName { get; set; }

        public string? MemoryDiskName { get; set; }

        public string? PowerUnitName { get; set; }

        public string? VideoCardName { get; set; }

        public string? MouseName { get; set; }
        public string? KeyboardName{ get; set; }
        public string? ScreenName { get; set; }

        public string? UserName {get; set;}
    }
}
