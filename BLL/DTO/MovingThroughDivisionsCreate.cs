

namespace BLL.DTO
{
    public class MovingThroughDivisionsCreate
    {
        public int ComputerPassportId { get; set; }
        public int OfficeOldId { get; set; }
        public int OfficeNewId { get; set; }
        public string? Note {  get; set; }

    }
}
