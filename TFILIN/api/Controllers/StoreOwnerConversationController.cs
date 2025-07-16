using api.PostModels;
using AutoMapper;
using core.DTOs;
using core.IServices;
using core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreOwnerConversationController : ControllerBase
    {
        private readonly IStoreOwnerConversationService _storeOwnerConversationService;
        private readonly IStatusCallService _statusCallService;
        private readonly IMapper _mapper;

        public StoreOwnerConversationController(IStoreOwnerConversationService storeOwnerConversationService, IStatusCallService StatusCallService, IMapper mapper)
        {
            _storeOwnerConversationService = storeOwnerConversationService;
            _statusCallService = StatusCallService;
            _mapper = mapper;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddConversation([FromBody] StoreOwnerConversationPostModel model)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            string userIdStr = User.FindFirst("UserId")?.Value;
            int userId = int.Parse(userIdStr);
            StatusCall statusCall=await _statusCallService.GetByIdAsync(model.statusCallId);

            StoreOwnerConversation conversation = new StoreOwnerConversation()
            {
                StoreOwnerId = model.StoreOwnerId,
                StoreStandId = model.StoreStandId,
                UserId = model.UserId,
                ConversionDate = model.ConversionDate,
                StatusCall = statusCall,
                Notes = model.notes,
                ToDoVisits = new List<ToDoVisit>(),
                Image = model.image,
                CreatedBy = userId,
                UpdatedBy = userId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
            await _storeOwnerConversationService.AddConversationAsync(conversation);
            return Ok(conversation);
        }

        [HttpGet]
        public async Task<ActionResult<List<StoreOwnerConversationDto>>> GetAll()
        {
            var list = await _storeOwnerConversationService.GetAllConversationsAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StoreOwnerConversationDto>> GetById(int id)//מחזיר על פי מזהה של שיחה
        {
            var conversation = await _storeOwnerConversationService.GetConversationByIdAsync(id);
            if (conversation == null)
                return NotFound();

            return Ok(conversation);
        }
        [HttpGet("id/{storeOwnerId}")]
        public async Task<ActionResult<List<StoreOwnerConversationDto>>> GetByStoreOwnerId(int storeOwnerId)//מחזיר על פי מזהה של בעל העסק שאיתו דיברו
        {
            List<StoreOwnerConversationDto> conversation = await _storeOwnerConversationService.GetConversationByStoreOwnerIdAsync(storeOwnerId);
            if (conversation == null)
                return NotFound();

            return Ok(conversation);
        }
    }
}
