namespace DAL.Models
{
    public class RepairComputer // Ремонт компьютера
    {
        public int Id { get; set; }

        public int? ComputerPassportId { get; set; }
        public ComputerPassport? ComputerPassport { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string? ServiceCenter { get; set; }

        public string? Note { get; set; }

        public StatusRepair Status { get; set; }
    }

    public enum StatusRepair
    {

    }

}
