using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ArrivalFromTheWareHouseAccept
    {
        public int? Id {  get; set; }
        public int? ComputerPassportId {  get; set; }
        public string? InventoryNumber { get; set; }

        public int? OfficeId {  get; set; }
        public int? Number {  get; set; }
        public int? Body {  get; set; }       

        public string? DepartmentName { get; set; }
    }
}
