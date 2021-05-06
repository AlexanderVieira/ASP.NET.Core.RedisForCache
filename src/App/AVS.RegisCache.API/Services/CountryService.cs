using AVS.RegisCache.API.Extensions;
using AVS.RegisCache.API.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AVS.RegisCache.API.Services
{
    public class CountryService : TextSerializerService, ICountryService
    {
        private readonly HttpClient _httpClient;
        const string COUNTRIES_URL = "/rest/v2/all";

        public CountryService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.CountriesUrl);
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            var response = await _httpClient.GetAsync(COUNTRIES_URL);            
            return await DeserializeResponseObject<IEnumerable<Country>>(response);
        }
    }
}
