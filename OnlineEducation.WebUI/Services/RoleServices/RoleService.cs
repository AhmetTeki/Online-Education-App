using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineEducation.Entity.Entities;
using OnlineEducation.WebUI.DTOs.RoleDtos;

namespace OnlineEducation.WebUI.Services.RoleServices
{
    public class RoleService(RoleManager<AppRole> _roleManager, IMapper _mapper) : IRoleService
    {
        public async Task CreateRoleAsync(CreateRoleDto dto)
        {
            var role = _mapper.Map<AppRole>(dto);
            await _roleManager.CreateAsync(role);
        }

        public async Task DeleteRoleAsync(int id)
        {
            var value =await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
        }

        public async Task<List<ResultRoleDto>> GetAllRolesAsync()
        {
            var values = await _roleManager.Roles.ToListAsync();
            return _mapper.Map<List<ResultRoleDto>>(values);
        }

        public Task<UpdateRoleDto> GetRoleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
