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

        Task<SignInResult> LoginAsync(LoginUserDto dto);

        Task LogoutAsync();

        Task<ApplicationUser?> GetByLoginAsync(string login);

        Task<IEnumerable<ApplicationUser>> GetAllAsync();

        Task<ApplicationUser?> GetByUserNameAsync(string userName);
    }
}
