using api.PostModels;
using AutoMapper;
using core.IServices;
using core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoVisitController : ControllerBase
    {
        private readonly IToDoVisitService _service;
        private readonly IMapper _mapper;

        public ToDoVisitController(IToDoVisitService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoVisit>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoVisit>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ToDoVisitPostModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string userIdStr = User.FindFirst("UserId")?.Value;
        
            int userId = int.Parse(userIdStr);
            ToDoVisit toDoVisit = new ToDoVisit()
            {
                ToDoId = model.ToDoId,
                VisitId = model.VisitId,
                StoreOwnerConversationId = model.StoreOwnerConversationId,
                Description = model.Description,
                Source = model.Source,
                Destination = model.Destination,
                CreatedBy = userId,
                UpdatedBy = userId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
            await _service.AddAsync(toDoVisit);
            return CreatedAtAction(nameof(GetById), new { id = toDoVisit.Id }, toDoVisit);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ToDoVisit toDovisit)
        {
            if (id != toDovisit.Id)
                return BadRequest("Id mismatch");

            await _service.UpdateAsync(toDovisit);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

    }
}
