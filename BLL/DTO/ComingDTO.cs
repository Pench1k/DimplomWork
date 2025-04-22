
namespace BLL.DTO
{
    public class ComingDTO
    {
        public int Id { get; set; }
        public string Provider { get; set; }
        public DateOnly DateOfComing { get; set; }
        public int? WarehouseId { get; set; }      
    }
}
