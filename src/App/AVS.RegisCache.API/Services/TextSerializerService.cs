using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AVS.RegisCache.API.Services
{
    public class TextSerializerService
    {
        protected StringContent GetContent(object obj)
        {
            return new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");
        }

        protected async Task<T> DeserializeResponseObject<T>(HttpResponseMessage response)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), options);
        }
    }
}
