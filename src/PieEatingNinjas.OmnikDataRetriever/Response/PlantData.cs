using Newtonsoft.Json;
using System;

namespace PieEatingNinjas.OmnikDataRetriever
{
    public class PlantData
    {
        [JsonProperty("total_energy")]
        public string TotalEnergy { get; set; }
        [JsonProperty("last_update_time")]
        public DateTime LastUpdateTime { get; set; }
        [JsonProperty("peak_power_actual")]
        public double PeakPowerActual { get; set; }
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("today_energy")]  
        public float TodayEnergy { get; set; }
        [JsonProperty("monthly_energy")]
        public float MonthlyEnergy { get; set; }
        [JsonProperty("yearly_energy")]
        public float YearlyEnergy { get; set; }
        [JsonProperty("current_power")]
        public float CurrentPower { get; set; }
        [JsonProperty("income")]
        public string Income { get; set; }
        [JsonProperty("carbon_offset")]
        public float CarbonOffset { get; set; }
        [JsonProperty("efficiency")]
        public float Efficiency { get; set; }
    }
}
