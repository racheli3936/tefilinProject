using AutoMapper;
using core.DTOs;
using core.IRepositories;
using core.IServices;
using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service
{
    public class CityService:ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        public CityService(ICityRepository cityRepository,IMapper mapper) 
        {
            _cityRepository = cityRepository;
            _mapper = mapper;

        }
        public async Task<List<CityDto>> GetAllCitiesAsync()
        {
            List<City> cities= await _cityRepository.GetAllCitiesAsync();
            List<CityDto> citiesDto = _mapper.Map<List<CityDto>>(cities);
            return citiesDto;
        }
        public async Task<City> GetCityByIdAsync(int cityId)
        {
            City city = await _cityRepository.GetCityById(cityId);
          
            return city;
        }
        public async Task<City> AddNewCityAsync(City city)
        {
             await _cityRepository.AddNewCityAsync(city);
            return city;
        }
    }
}
