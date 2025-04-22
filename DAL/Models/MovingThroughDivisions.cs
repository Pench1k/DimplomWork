namespace DAL.Models
{
    public class MovingThroughDivisions // Перемещение по подразделениям // Подумать над статусами
    {
        public int Id { get; set; }

        public int? ComputerPassportId { get; set; }
        public ComputerPassport? ComputerPassport { get; set; }

        public int? OfficeOldId { get; set; }
        public Office? OfficeOld { get; set; }

        public int? OfficeNewId { get; set; }
        public Office? OfficeNew { get; set; }


        public int? WorkerId { get; set; }
        public Workers? Workers { get; set; }

        public DateOnly DateOfMovingThroughDivisions { get; set; }
        public string Note { get; set; }

        public StatusForMoving Status { get; set; }
    }

    public enum StatusForMoving
    {

    }

}
