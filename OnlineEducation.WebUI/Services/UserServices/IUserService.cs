using Microsoft.AspNetCore.Identity;
using OnlineEducation.Entity.Entities;
using OnlineEducation.WebUI.DTOs.UserDtos;

namespace OnlineEducation.WebUI.Services.UserServices
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto);
        Task<string> LoginAsync(UserLoginDto userLoginDto);
        Task<bool> LogoutAsync();

        Task<bool> CreateRoleAsync(UserRoleDto userRoleDto);
        Task<bool> AssignRoleAsync(List<AssignRoleDto> assignRoleDto);
        Task<List<AppUser>> GetAllUsersAsync();
        Task<List<AppUser>> GetAllTeacher();
        Task<AppUser> GetAllUsersByIdAsync(int id);
    }
}
