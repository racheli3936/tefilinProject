using core.DTOs;
using core.IServices;
using core.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetUserById(int id)
        //{
        //    var user = await _userService.GetUserByIdAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(user);
        //}

        //[HttpPost]
        //public async Task<ActionResult> AddUser(User user)
        //{
        //    await _userService.AddUserAsync(user);
        //    return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateUser(int id, User user)
        //{
        //    if (id != user.Id)
        //    {
        //        return BadRequest();
        //    }
        //    await _userService.UpdateUserAsync(user);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteUser(int id)
        //{
        //    await _userService.DeleteUserAsync(id);
        //    return NoContent();
        //}
    }
}
