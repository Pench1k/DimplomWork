namespace DAL.Models
{
    public class WriteDowns // Списание
    {
        public int Id { get; set; }

        public int? ComputerPassportId { get; set; }
        public ComputerPassport? ComputerPassport { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string? Note { get; set; }

        public StatusWrite Status { get; set; }

    }
    public enum StatusWrite
    {

    }

}
