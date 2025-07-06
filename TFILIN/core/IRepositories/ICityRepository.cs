using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.IRepositories
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllCitiesAsync();
        Task AddNewCityAsync(City city);
    }
}
