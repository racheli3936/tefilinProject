using core.DTOs;
using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.IServices
{
    public interface ICityService
    {
        Task<List<CityDto>> GetAllCitiesAsync();
        Task<City> GetCityByIdAsync(int cityId);
        Task<City> AddNewCityAsync(City city);
    }
}
