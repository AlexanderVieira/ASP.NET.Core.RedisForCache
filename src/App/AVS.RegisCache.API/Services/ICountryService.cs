using AVS.RegisCache.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AVS.RegisCache.API.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountries();
    }
}
