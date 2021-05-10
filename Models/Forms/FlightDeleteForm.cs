using Newtonsoft.Json;

namespace FlightSchedule.Models.Forms
{
    public class FlightDeleteForm
    {
        [JsonProperty("flightId", Required = Required.Always)]
        public string FlightId { get; set; }
    }
}