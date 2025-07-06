using api.PostModels;
using AutoMapper;
using core.DTOs;
using core.IServices;
using core.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public AuthController(IAuthService authService,IRoleService roleService, IMapper mapper) 
        {
            _authService = authService;
            _roleService = roleService;
            _mapper = mapper;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            try
            {
                var (token, user) = await _authService.LoginAsync(login.Email,login.Password);
                var dtoUser = _mapper.Map<UserDto>(user);
                return Ok(new { Token = token, User = dtoUser });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserPostModel userPost)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(userPost.Password);
            Role role=await _roleService.GetRoleByNameAsync(userPost.Role.RoleName);
           if(role == null)
            {
                return BadRequest(new { error = "Role not found." });
            }
            var user = new User
            {
                FullName = userPost.FullName,
                Phone = userPost.Phone,
                Email = userPost.Email,
                Address = userPost.Address,
                Password = passwordHash,
                RoleId = role.Id,
                CreatedDate=DateTime.Now,
                UpdatedDate=DateTime.Now,
            };

            var token = await _authService.RegisterUserAsync(user);
            return Ok(new { Token = token });
        }
    }
}
