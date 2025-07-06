using api.PostModels;
using AutoMapper;
using core.DTOs;
using core.IServices;
using core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }
        [HttpGet("role/by-name/{roleName}")]
        public async Task<IActionResult> GetRoleByName(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                return BadRequest("יש לספק שם תפקיד");

            var role = await _roleService.GetRoleByNameAsync(roleName);

            if (role == null)
                return NotFound("לא נמצא תפקיד עם השם הזה");

            return Ok(role);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateRole(RolePostModel newRole)
        {
            string userIdStr = User.FindFirst("UserId")?.Value;

            int userId = int.Parse(userIdStr);
            Console.WriteLine(userId);

            Role role = new Role()
            {
                RoleName = newRole.RoleName,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatedBy = userId,
                UpdatedBy = userId
            };
            try
            {
                _roleService.CreateRoleAsync(role);
                RoleDto roleDto = _mapper.Map<RoleDto>(role);
                return Ok(roleDto);
            }
            catch (Exception ex) 
            { 
                return StatusCode(500, ex.Message);
            }
           
        }

    }
}
