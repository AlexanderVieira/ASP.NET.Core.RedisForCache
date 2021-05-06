using AVS.RegisCache.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;

namespace AVS.RegisCache.API.Controllers
{
    [ApiController]
    [Route("api/cache")]
    public class CountriesController : Controller
    {
        private readonly IDistributedCache _distributedCache;
        private readonly CountryService _countryService;
        private const string KEY = "Countries";

        public CountriesController(IDistributedCache distributedCache, CountryService countryService)
        {
            _distributedCache = distributedCache;
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _distributedCache.GetStringAsync(KEY);
            if (!string.IsNullOrWhiteSpace(countries))
            {
                return Ok(countries);
            }
            else
            {
                var response = await _countryService.GetCountries();
                var memoryCacheEntryOptions = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600),
                    SlidingExpiration = TimeSpan.FromSeconds(1200)
                };

                await _distributedCache.SetStringAsync(KEY, response.ToString(), memoryCacheEntryOptions);
                
            }

            return Ok(countries);
        }
    }
}
