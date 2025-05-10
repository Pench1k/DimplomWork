namespace BLL.DTO
{
    public class UpdateUserDTO
    {
        public string Id { get; set; } = null!;

        public string UserName { get; set; }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? NewPassword { get; set; }
    }
}
