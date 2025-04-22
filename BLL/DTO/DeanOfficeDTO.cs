

using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class DeanOfficeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DeanOfficeCreate
    { 
       [Required] public string Name { get; set;}
    }

}
