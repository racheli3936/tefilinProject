using api.PostModels;
using core.IServices;
using core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TefilinStatusController : ControllerBase
    {
        private readonly ITefilinStatusService _tefilinStatusService;

        public TefilinStatusController(ITefilinStatusService tefilinStatusService)
        {
           _tefilinStatusService = tefilinStatusService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TefilinStatus>> GetById(int id)
        {
            var result = await _tefilinStatusService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TefilinStatus>>> GetAll()
        //{
        //    var results = await _tefilinStatusService.GetAllAsync();
        //    return Ok(results);
        //}
        //[Authorize]
        //[HttpPost]
        //public async Task<ActionResult> Add(TefilinStatusPostModel statusPostModel)
        //{
        //    string userIdStr = User.FindFirst("UserId")?.Value;
        //    int userId = int.Parse(userIdStr);
        //    TefilinStatus status = new TefilinStatus()
        //    {
        //        Status = statusPostModel.Status,
        //        CreatedBy=userId,
        //        UpdatedBy=userId,
        //        CreatedDate=DateTime.Now,
        //        UpdatedDate=DateTime.Now
        //    };
        //    await _tefilinStatusService.AddAsync(status);
        //    return CreatedAtAction(nameof(GetById), new { id = status.Status }, status);
        //}
        //[Authorize]
        //[HttpPut("{id}")]
        //public async Task<ActionResult> Update(int id, TefilinStatusPostModel model)
        //{
        //    string userIdStr = User.FindFirst("UserId")?.Value;
        //    int userId = int.Parse(userIdStr);
        //    TefilinStatus status = new TefilinStatus()
        //    {
        //        Status = model.Status,
        //        CreatedBy = userId,
        //        UpdatedBy = userId,
        //        CreatedDate = DateTime.Now,
        //        UpdatedDate = DateTime.Now
        //    };
        //    await _tefilinStatusService.UpdateAsync(id, status);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    await _tefilinStatusService.DeleteAsync(id);
        //    return NoContent();
        //}
    }
}
