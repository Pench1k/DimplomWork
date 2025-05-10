using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserEditDTO
    {
        public string? Id {  get; set; }

        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public IList<string>? Roles {  get; set; }

        public string? password { get; set; }
    }
}
