using System;
using System.ComponentModel.DataAnnotations;

namespace FlightSchedule.Models
{
    public class Flight
    {
        [Key] public int FlightId { get; set; }
        public City DepartureCity  { get; set; }
        public City DestinationCity  { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime LandingTime { get; set; }
    }
}