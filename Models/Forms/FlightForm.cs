using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FlightSchedule.Models.Forms
{
    public class FlightForm
    {
        [JsonProperty("flightId", Required = Required.Always)]
        public string FlightId { get; set; }
        
        [JsonProperty("departureCityId", Required = Required.Always)]
        public string DepartureCityId { get; set; }

        [JsonProperty("destinationCityId", Required = Required.Always)]
        public string DestinationCityId { get; set; }

        [JsonProperty("departureTime", Required = Required.Always)]
        public DateTime DepartureTime { get; set; }

        [JsonProperty("landingTime", Required = Required.Always)]
        public DateTime LandingTime { get; set; }
    }
}