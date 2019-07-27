using Newtonsoft.Json;

namespace PieEatingNinjas.OmnikDataRetriever
{
    public class ApiResponse<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }
        [JsonProperty("error_msg")]
        public string ErrorMessage { get; set; }
        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }
    }
}
