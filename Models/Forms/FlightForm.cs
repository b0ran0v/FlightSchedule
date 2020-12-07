using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FlightSchedule.Models.Forms
{
    public class FlightForm
    {
        [JsonProperty("departureCity")] public string DepartureCity { get; set; }

        [JsonProperty("destinationCity")] public string DestinationCity { get; set; }

        [JsonProperty("departureTime")] public DateTime DepartureTime { get; set; }

        [JsonProperty("landingTime")] public DateTime LandingTime { get; set; }
    }
}