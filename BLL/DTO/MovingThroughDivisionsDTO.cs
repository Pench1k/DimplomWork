

namespace BLL.DTO
{
    public class MovingThroughDivisionsDTO
    {
        public int Id { get; set; }

        public int? ComputerPassportId { get; set; }
        

        public int? OfficeOldId { get; set; }
        

        public int? OfficeNewId { get; set; }
        


        public int? WorkerId { get; set; }
        

        public DateOnly DateOfMovingThroughDivisions { get; set; }
        public string Note { get; set; }

    
    }
}
