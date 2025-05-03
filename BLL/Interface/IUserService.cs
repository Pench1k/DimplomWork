using BLL.DTO;
using DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace BLL.Interface
{
    public interface IUserService
    {
        Task<bool> Add(RegisterUserDto user);
        Task<bool> Update(ApplicationUser user);
        Task Delete(ApplicationUser user);

        Task<string> LoginAsync(LoginUserDto dto);

        Task LogoutAsync();      
        Task<IEnumerable<ApplicationUser>> GetAllAsync();

        Task<IEnumerable<string>> GetRolesAsync(ApplicationUser user);

        Task<ApplicationUser?> GetByUserNameAsync(string userName);
    }
}
