using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FlightSchedule.Models
{
    public class Flight
    {
        [Key] public int FlightId { get; set; }

        [Required] public City DepartureCity { get; set; }

        [Required] public City DestinationCity { get; set; }

        [Required] public DateTime DepartureTime { get; set; }

        [Required] public DateTime LandingTime { get; set; }
    }
}