using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public  class RepairComputerCreate
    {
        public int ComputerPassportId {  get; set; }
        public string? ServiceCentre {  get; set; }
        public string? Note {  get; set; }
    }
}
