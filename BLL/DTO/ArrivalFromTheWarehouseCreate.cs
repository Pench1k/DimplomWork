

namespace BLL.DTO
{
    public class ArrivalFromTheWarehouseCreate
    {
        public int ComputerPassportId { get; set; }
        public int WarehouseId { get; set; }
        public int OfficeId {  get; set; }
        public string? ResponsibleUserId { get; set; }
        public string? Note {  get; set; }

    }
}
