using BLL.DTO;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BLL.Interface
{
    public interface IUserService
    {
        Task<bool> Add(RegisterUserDto user);    
        Task<IdentityResult> Delete(ApplicationUser user);

        Task<string> LoginAsync(LoginUserDto dto);

        Task LogoutAsync();
        Task<IEnumerable<UserDTO>> GetAllAsync();

        Task<IEnumerable<string>> GetRolesAsync(ApplicationUser user);

        Task<ApplicationUser?> GetByUserNameAsync(string userName);

        Task<ApplicationUser?> GetUserAsync(ClaimsPrincipal user);
        Task<ApplicationUser?> GetByIdAsync(string id);

        Task<bool> UserExistAsync(string username);

        Task<UserEditDTO?> GetUserByEdit(string id);

        Task<IdentityResult> UpdateUserAsync(UpdateUserDTO dto);

        Task<IEnumerable<UserByDepartment>> GetByDepartmentId(int departmentId);
    }
}
