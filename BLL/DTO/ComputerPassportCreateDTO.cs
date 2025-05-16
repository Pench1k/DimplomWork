using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ComputerPassportCreateDTO
    {
        public string InventoryNumber { get; set; }

        public int ComputerId { get; set; }

        public DateOnly DateOfDebit { get; set; }
    }
}
