using BLL.DTO;
using BLL.Interface;
using DAL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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

                    DepartmentId = dto.DepartmentId,
                    WarehouseId = dto.WarehouseId
                };

                var result = await _userManager.CreateAsync(user, dto.Password);
                if (!result.Succeeded)
                    return false;
                result = await _userManager.AddToRoleAsync(user, dto.Role);
                if (!result.Succeeded) 
                    return false;
                return true;
            }
            catch
            {
                return false;
            }      
        }

        public async Task<IdentityResult> Delete(ApplicationUser user) //???
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return await _userManager.DeleteAsync(user);
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var userAll = await _userManager.Users.ToListAsync();
            var userDto = new List<UserDTO>();

            foreach (var user in userAll)
            {
                var roles = await _userManager.GetRolesAsync(user);

                var departmentId = user.DepartmentId;
                var warehouseId = user.WarehouseId;

                var department = departmentId.HasValue ? await _unitOfWork.Department.GetByIdAsync(departmentId.Value) : null;
                var warehouse = warehouseId.HasValue ? await _unitOfWork.Warehouse.GetByIdAsync(warehouseId.Value) : null;

                userDto.Add(new UserDTO
                {
                    Id = user.Id,

                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    MiddleName = user.MiddleName,
                    LastName = user.LastName,

                    DepartmentId = departmentId,
                    WarehouseId = warehouseId,

                    WarehouseName = warehouse?.Name ?? "-",
                    DepartmentName = department?.Name ?? "-",
                    Roles = roles
                });
            }
            return userDto;
        }

        public async Task<ApplicationUser?> GetByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<ApplicationUser?> GetByUserNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<IEnumerable<string>> GetRolesAsync(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<ApplicationUser?> GetUserAsync(ClaimsPrincipal user)
        {
            return await _userManager.GetUserAsync(user);
        }

        public async Task<UserEditDTO?> GetUserByEdit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return null;

            var roles = await _userManager.GetRolesAsync(user);

            return new UserEditDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Roles = roles.ToList()
            };
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

        public async Task<IdentityResult> UpdateUserAsync(UpdateUserDTO dto)
        {
            var user = await _userManager.FindByIdAsync(dto.Id);
            if (user == null)
                return IdentityResult.Failed(new IdentityError
                {
                    Code = "UserNotFound",
                    Description = "Пользователь не найден"
                });

           
            if (!string.Equals(user.UserName, dto.UserName, StringComparison.OrdinalIgnoreCase))
            {
                var existingUser = await _userManager.FindByNameAsync(dto.UserName);
                if (existingUser != null && existingUser.Id != user.Id)
                {
                    return IdentityResult.Failed(new IdentityError
                    {
                        Code = "DuplicateUserName",
                        Description = $"Логин '{dto.UserName}' уже занят другим пользователем"
                    });
                }

                user.UserName = dto.UserName;
                user.NormalizedUserName = _userManager.NormalizeName(dto.UserName);
            }


            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.MiddleName = dto.MiddleName;

          
            if (!string.IsNullOrEmpty(dto.NewPassword))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResult = await _userManager.ResetPasswordAsync(user, token, dto.NewPassword);
                if (!passwordResult.Succeeded)
                    return passwordResult;
            }

          
            return await _userManager.UpdateAsync(user);
        }

        public async Task<bool> UserExistAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
                return false;
            return true;
        }
    }
}
