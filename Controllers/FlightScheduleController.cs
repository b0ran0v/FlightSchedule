﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FlightSchedule.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FlightSchedule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightScheduleController : ControllerBase
    {
        private readonly ILogger<FlightScheduleController> _logger;

        public FlightScheduleController(ILogger<FlightScheduleController> logger)
        {
            _logger = logger;
            
        }

        public Flight[] InitializeExampleData()
        {
            City city1 = new City{CityId = 1, Name = "Astana"};
            City city2 = new City{CityId = 2, Name = "Almaty"};
            City city3 = new City{CityId = 6, Name = "Atyrau"};
            Flight[] flights = {
                new Flight
                {
                    FlightId = 3,
                    DepartureCity = city1,
                    DestinationCity = city3,
                    DepartureTime = DateTime.Now.AddHours(12),
                    LandingTime = DateTime.Now.AddHours(14.5)
                },
                new Flight
                {
                    FlightId = 4,
                    DepartureCity = city3,
                    DestinationCity = city1,
                    DepartureTime = DateTime.Now.AddDays(1).AddHours(8),
                    LandingTime = DateTime.Now.AddDays(1).AddHours(10.5)
                },
                new Flight
                {
                    FlightId = 1,
                    DepartureCity = city2,
                    DestinationCity = city1,
                    DepartureTime = DateTime.Now,
                    LandingTime = DateTime.Now.AddHours(1.5)
                },
                new Flight
                {
                    FlightId = 2,
                    DepartureCity = city3,
                    DestinationCity = city2,
                    DepartureTime = DateTime.Now.AddDays(1).AddHours(3),
                    LandingTime = DateTime.Now.AddDays(1).AddHours(6.5)
                }
            };

            return flights;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
        
        [HttpGet("getSchedule")]
        [Produces("application/json")]
        public IActionResult GetSchedule(string date)
        {
            try
            {
                DateTime currentDate = Convert.ToDateTime(date);
                var flights = InitializeExampleData();
                var currentFlights = flights.Where(flight => flight.DepartureTime.Date.Day == currentDate.Day)
                    .OrderBy(flight => flight.DepartureTime);
                return Ok(currentFlights);
            }
            catch (FormatException)
            {
                return BadRequest();
            }
        }
    }
}