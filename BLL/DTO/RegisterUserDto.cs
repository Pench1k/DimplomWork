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
        [Required(ErrorMessage = "Логин обязателен")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Логин должен быть от 3 до 50 символов")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Пароль должен содержать минимум 8 символов")]
        public string Password { get; set; }
        [Required] public string Role {  get; set; }

        [Required(ErrorMessage = "Имя обязательно")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Фамилия обязательно")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Отчество обязательно")]
        public string MiddleName { get; set; }

        public int? DepartmentId { get; set; }
        public int? WarehouseId { get; set; }
    }
}
