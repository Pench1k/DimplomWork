namespace DAL.Models
{
    public class Coming // Приход // Подумать над полями 
    {
        public int Id { get; set; }
        public string? Provider {  get; set; }
        public DateOnly? DateOfComing { get; set; }

        public string? DocumentNumber { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public List<ComputerPassport>? ComputerPassports { get; set; }
        //???
    }
}
