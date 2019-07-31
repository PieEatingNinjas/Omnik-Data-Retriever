using Newtonsoft.Json;

namespace PieEatingNinjas.OmnikDataRetriever
{
    public class Plant
    {
        [JsonProperty("total_energy")]
        public float TotalEnergy { get; set; }
        [JsonProperty("plant_id")]
        public int PlantId { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
        [JsonProperty("latitude")]
        public string Latitude { get; set; }
        [JsonProperty("line_status")]
        public string LineStatus { get; set; }
        [JsonProperty("peak_power")]
        public float PeakPower { get; set; }
        [JsonProperty("installer")]
        public string Installer { get; set; }
        [JsonProperty("user_id")]
        public int UserId { get; set; }
        [JsonProperty("alarm_status")]
        public string AlarmStatus { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("eday")]
        public float Eday { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("create_date")]
        public string CreateDate { get; set; }
        [JsonProperty("longitude")]
        public string Longitude { get; set; }
        [JsonProperty("_operator")]
        public string Operator { get; set; }
        [JsonProperty("locale")]
        public string Locale { get; set; }
        [JsonProperty("income")]
        public string Income { get; set; }
        [JsonProperty("current_power")]
        public float CurrentPower { get; set; }
        [JsonProperty("today_energy")]
        public float TodayEnergy { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
    }
}
