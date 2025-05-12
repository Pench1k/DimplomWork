
namespace BLL.DTO
{
    public class ComingDTO
    {
        public int? Id { get; set; }
        public string? Provider { get; set; }
        public DateOnly? DateOfComing { get; set; }
        public string? DocumentNumber { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
    }
}
