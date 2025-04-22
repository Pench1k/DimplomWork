

namespace BLL.DTO
{
    public class ComputerPassportDTO
    {

        public int Id { get; set; }

        public int InventoryNumber { get; set; }

        public int? ComputerId { get; set; }
       

        public DateOnly DateOfReceipt { get; set; }
        public DateOnly DateOfDebit { get; set; }

        public int? WorkerId { get; set; }
        
        public int? OfficeId { get; set; }
        
        public int? WarehouseId { get; set; }
       
    }
}
