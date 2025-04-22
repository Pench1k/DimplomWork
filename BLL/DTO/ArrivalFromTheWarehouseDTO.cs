

namespace BLL.DTO
{
    public class ArrivalFromTheWarehouseDTO
    {
        public int Id { get; set; }

        public int? ComputerPassportId { get; set; }
        public int? WarehouseId { get; set; }
        public int? OfficeId { get; set; }    
        public int? WorkerId { get; set; }
        public DateOnly DateOfArrivalFromTheWarehouse { get; set; }
        public string Note { get; set; }
        
    }
}
