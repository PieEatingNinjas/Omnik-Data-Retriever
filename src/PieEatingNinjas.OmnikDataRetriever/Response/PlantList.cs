using Newtonsoft.Json;

namespace PieEatingNinjas.OmnikDataRetriever
{

    public class PlantList
    {
        [JsonProperty("plants")]
        public Plant[] Plants { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
