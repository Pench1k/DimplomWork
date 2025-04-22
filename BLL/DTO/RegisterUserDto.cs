using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class RegisterUserDto
    {

        [Required] public string UserName { get; set; }
        [Required][PasswordPropertyText] public string Password { get; set; }

        [Required] public string Role {  get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string MiddleName { get; set; }

        public int? DepartmentId { get; set; }
        public int? WarehouseId { get; set; }
    }
}
