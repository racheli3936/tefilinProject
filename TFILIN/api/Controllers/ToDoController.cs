using api.PostModels;
using core.DTOs;
using core.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoPostService)
        {
            _toDoService = toDoPostService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDoDto>>> GetAll()
        {
            var toDoPosts = await _toDoService.GetAllAsync();
            return Ok(toDoPosts);
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<ToDoPostModel>> GetById(int id)
        //{
        //    var toDoPost = await _toDoService.GetByIdAsync(id);
        //    if (toDoPost == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(toDoPost);
        //}

        //[HttpPost]
        //public async Task<ActionResult> Create(ToDoPostModel toDoPost)
        //{
        //    await _toDoService.CreateAsync(toDoPost);
        //    return CreatedAtAction(nameof(GetById), new { id = toDoPost.Id }, toDoPost);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult> Update(int id, ToDoPostModel toDoPost)
        //{
        //    if (id != toDoPost.Id)
        //    {
        //        return BadRequest();
        //    }
        //    await _toDoService.UpdateAsync(toDoPost);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    await _toDoService.DeleteAsync(id);
        //    return NoContent();
        //}
    }
}
