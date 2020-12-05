using System.ComponentModel.DataAnnotations;

namespace FlightSchedule.Models
{
    public class City
    {
        [Key] public int CityId { get; set; }
        public string Name { get; set; }
    }
}