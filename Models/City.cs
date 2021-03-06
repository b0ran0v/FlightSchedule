﻿using System.ComponentModel.DataAnnotations;

namespace FlightSchedule.Models
{
    public class City
    {
        [Required] [Key] [StringLength(3)] public string CityId { get; set; }

        [Required] public string Name { get; set; }
    }
}