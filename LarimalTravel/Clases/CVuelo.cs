using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LarimalTravel
{
    public class CVuelo : IServicio
    {
        [JsonProperty("horario")]
        public DateTime horario { get; set; }
        [JsonProperty("codigo")]
        public int codigo { get; set; }
        [JsonProperty("destino")]
        public string destino { get; set; }
        [JsonProperty("asiento")]
        public string asiento { get; set; }

        public IServicio[] Get()
        {
            string json = File.ReadAllText("Json/Vuelos.json");
            CVuelo[] vuelos = JsonConvert.DeserializeObject<CVuelo[]>(json);
            return vuelos;
        }
    }
}
