using Newtonsoft.Json;

namespace PieEatingNinjas.OmnikDataRetriever
{
    public class UserData
    {
        [JsonProperty("c_user_id")]
        public string UserId { get; set; }
        [JsonProperty("user_type")]
        public int UserType { get; set; }
        [JsonProperty("plant_count")]
        public int PlantCount { get; set; }
    }
}
