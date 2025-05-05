using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserDTO 
    {
        public string UserName { get; set; }      

        public IEnumerable<string> Roles { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public string? DepartmentName { get; set; }
        public string? WarehouseName { get; set; }
    }
}
