using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class WriteDowns // Списание
    {
        public int Id { get; set; }

        public int? ComputerPassportId { get; set; }
        public ComputerPassport? ComputerPassport { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int WarehouseId {  get; set; }
        public Warehouse Warehouse { get; set; }

        public DateOnly DateOfWriteDowns { get; set; }
        public string? Note { get; set; }

        public StatusWrite Status { get; set; }

    }
    public enum StatusWrite
    {
        [Display(Name = "Ожидает подтверждение от склада")]
        WaiteWarehouse,

        [Display(Name = "Получен")]
        Received
    }

}
