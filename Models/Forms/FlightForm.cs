using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FlightSchedule.Models.Forms
{
    public class FlightForm
    {
        [JsonProperty("departureCity", Required = Required.Always)]
        public string DepartureCity { get; set; }

        [JsonProperty("destinationCity", Required = Required.Always)]
        public string DestinationCity { get; set; }

        [JsonProperty("departureTime", Required = Required.Always)]
        public DateTime DepartureTime { get; set; }

        [JsonProperty("landingTime", Required = Required.Always)]
        public DateTime LandingTime { get; set; }
    }
}