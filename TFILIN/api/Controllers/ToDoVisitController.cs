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
        private readonly IToDoVisitService _toDoVisitservice;
        private readonly IMapper _mapper;

        public ToDoVisitController(IToDoVisitService service, IMapper mapper)
        {
            _toDoVisitservice = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoVisit>>> GetAll()
        {
            var list = await _toDoVisitservice.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoVisit>> GetById(int id)
        {
            var item = await _toDoVisitservice.GetByIdAsync(id);
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
            await _toDoVisitservice.AddAsync(toDoVisit);
            return CreatedAtAction(nameof(GetById), new { id = toDoVisit.Id }, toDoVisit);
        }
        [Authorize]
        [HttpPost("list")]
        public async Task<ActionResult> CreateFromList([FromBody] List<ToDoVisitPostModel> models)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string? userIdStr = User.FindFirst("UserId")?.Value;
            if (!int.TryParse(userIdStr, out int userId))
                return Unauthorized();

            var toDoVisits = models.Select(model => new ToDoVisit
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
            }).ToList();
            foreach (var visit in toDoVisits)
            {
                await _toDoVisitservice.AddAsync(visit);
            }
            return Ok(toDoVisits);
        }
       

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ToDoVisit toDovisit)
        {
            if (id != toDovisit.Id)
                return BadRequest("Id mismatch");

            await _toDoVisitservice.UpdateAsync(toDovisit);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _toDoVisitservice.DeleteAsync(id);
            return NoContent();
        }

    }
}
