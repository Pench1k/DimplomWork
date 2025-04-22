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

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(RegisterUserDto dto)
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

            var worker = new Workers
            { 
                ApplicationUserId = user.Id,
                DepartmentId = dto.DepartmentId,    
                WarehouseId = dto.WarehouseId,
            };

            _unitOfWork.Workers.Create(worker);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public  Task Delete(ApplicationUser user)
        {
           return  _userManager.DeleteAsync(user);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<ApplicationUser?> GetByLoginAsync(string login)
        {
            return await _userManager.FindByNameAsync(login);
        }

        public async Task<ApplicationUser?> GetByUserNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<SignInResult> LoginAsync(LoginUserDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

           
            var user = await _userManager.FindByNameAsync(dto.UserName);
            if (user == null)
                return SignInResult.Failed;

           
            var result = await _signInManager.PasswordSignInAsync(user, dto.Password, isPersistent: false, lockoutOnFailure: false);

            return result;
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
