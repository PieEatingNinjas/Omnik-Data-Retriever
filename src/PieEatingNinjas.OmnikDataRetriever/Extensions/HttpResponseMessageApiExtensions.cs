using System.Net.Http;
using System.Threading.Tasks;

namespace PieEatingNinjas.OmnikDataRetriever.Extensions
{
    internal static class HttpResponseMessageApiExtensions
    {
        internal static async Task<ApiResponse<T>> AsApiResponse<T>(this Task<HttpResponseMessage> task)
        {
            var response = await task;

            var json = await response.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResponse<T>>(json);
        }
    }
}
