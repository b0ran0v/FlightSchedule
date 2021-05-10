using System;
using Newtonsoft.Json;

namespace FlightSchedule.Models.Forms
{
    public class FlightUpdateForm
    {
        [JsonProperty("departureTime", Required = Required.Always)]
        public DateTime DepartureTime { get; set; }

        [JsonProperty("landingTime", Required = Required.Always)]
        public DateTime LandingTime { get; set; }
    }
}