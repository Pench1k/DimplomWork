using BLL.DTO;
using BLL.Interface;
using DAL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BLL.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        public async Task<bool> Add(RegisterUserDto dto)
        {
            try
            {
                var user = new ApplicationUser
                {
                    UserName = dto.UserName,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    MiddleName = dto.MiddleName,
                };

                var result = await _userManager.CreateAsync(user, dto.Password);


                if (!result.Succeeded)
                    return false;
                result = await _userManager.AddToRoleAsync(user, dto.Role);
                if (!result.Succeeded) return false;


                //if (dto.WarehouseId != 0 || dto.DepartmentId != 0)
                //{
                //    user = await _userManager.FindByNameAsync(dto.UserName);
                //    var worker = new Workers
                //    {
                //        ApplicationUserId = user.Id,
                //        DepartmentId = dto.DepartmentId,
                //        WarehouseId = dto.WarehouseId,
                //    };

                //    await _unitOfWork.BeginTransactionAsync();
                //    await _unitOfWork.Workers.AddAsync(worker);
                //    await _unitOfWork.CommitAsync();
                //}
                return true;
            }
            catch
            {
                return false;
            }      
        }

        public Task Delete(ApplicationUser user)
        {
            return _userManager.DeleteAsync(user);
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var userAll = await _userManager.Users.ToListAsync();
            var userDto = new List<UserDTO>();

            foreach (var user in userAll)
            {
                var roles = await _userManager.GetRolesAsync(user);               
                
                userDto.Add(new UserDTO
                {
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    MiddleName = user.MiddleName,
                    LastName = user.LastName,                   
                    Roles = roles
                });
            }
            return userDto;
        }

        public async Task<ApplicationUser?> GetByUserNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<IEnumerable<string>> GetRolesAsync(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<string> LoginAsync(LoginUserDto dto)
        {
            var user = await GetByUserNameAsync(dto.UserName);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, dto.Password, false, false);
                if (result.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    return _tokenService.CreateToken(user, roles);
                }

            }
            throw new Exception("Failed to login");
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> Update(ApplicationUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }
    }
}
