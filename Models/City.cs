using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FlightSchedule.Models
{
    public class City
    {
        [Key] 
        public int CityId { get; set; }
        
        [Required] 
        public string Name { get; set; }
    }
}