using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class RepairComputerOnDepartment
    {
        public int Id { get; set; }
        public int? ComputerPassportId { get; set;}
        public string? InventoryNumber { get; set; }

        public string? ServiceCenter {get; set;}
        public string? Note { get; set; }

        public int? Body {  get; set; }
        public int? Number {  get; set; }

        public DateOnly DateOfRepairComputer { get; set; }
        public StatusRepair Status { get; set; }
    }
}
