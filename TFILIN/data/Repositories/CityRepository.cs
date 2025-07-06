using core.IRepositories;
using core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repositories
{
    public class CityRepository:ICityRepository
    {
        private readonly DataContext _context;
        public CityRepository(DataContext context) 
        {
            _context = context;
        }
        public async Task<List<City>>GetAllCitiesAsync()
        {
            return await _context.Cities.ToListAsync();
        }
        public async Task AddNewCityAsync(City city)
        {
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
            
        }
        

    }
}
