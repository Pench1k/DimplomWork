using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class WriteDownWarehouseAccept
    {
        public int Id { get; set; } 

        public int? ComputerPassportId { get; set; }
        public string? InventoryNumber {  get; set; }

        public int? WarehouseId { get; set; }
        public string? WarehouseName { get; set; }

        public DateOnly DateOfWriteDowns { get; set; }

        public string? Note {  get; set; }

    }
}
