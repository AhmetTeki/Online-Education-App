using OnlineEducation.WebUI.DTOs.RoleDtos;

namespace OnlineEducation.WebUI.Services.RoleServices
{
    public interface IRoleService
    {
        Task<List<ResultRoleDto>> GetAllRolesAsync();
        Task<UpdateRoleDto> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(CreateRoleDto dto);
        Task DeleteRoleAsync(int id);
    }
}
