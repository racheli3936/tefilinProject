using api.PostModels;
using core.DTOs;
using core.IServices;
using core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService) 
        {
            _cityService = cityService;
        }
        [HttpGet]
        public async Task<ActionResult<List<CityDto>>> GetAllDonors()
        {
            List<CityDto> cities = await _cityService.GetAllCitiesAsync();
            return Ok(cities);
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddCity(CityPostModel newCity)
        {
            Console.WriteLine( "before add city");
            string userIdStr = User.FindFirst("UserId")?.Value;
            Console.WriteLine(userIdStr+"_______________________");
            int userId = int.Parse(userIdStr);
    
            City city= new City()
            {
                CityName=newCity.CityName,
                CreatedDate=DateTime.Now,
                UpdatedDate=DateTime.Now,
                CreatedBy=userId,
                UpdatedBy=userId,
            };
            try
            {
               City cityAdded=await _cityService.AddNewCityAsync(city);
                return Ok(cityAdded);

            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
                return StatusCode(500,ex.Message);
            }
            

        }

    }
}
