using System;
using System.ComponentModel.DataAnnotations;

namespace FlightSchedule.Models
{
    public class Flight
    {
        [Required] [Key] [StringLength(10)] public string FlightId { get; set; }

        [Required] public City DepartureCity { get; set; }

        [Required] public City DestinationCity { get; set; }

        [Required] public DateTime DepartureTime { get; set; }

        [Required] public DateTime LandingTime { get; set; }
    }
}