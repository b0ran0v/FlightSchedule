using System;
using System.Linq;
using FlightSchedule.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FlightSchedule.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightScheduleController : ControllerBase
    {
        private readonly ILogger<FlightScheduleController> _logger;
        private readonly ApplicationDbContext _context;

        public FlightScheduleController(ILogger<FlightScheduleController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        // Get Schedule By Flight Date and Cities
        [HttpGet("get-schedule-by-date")]
        [Produces("application/json")]
        public IActionResult GetSchedule(string date, string departureCityId, string destinationCityId)
        {
            if (!Tools.Tools.ContainsAllParameters(date, departureCityId, destinationCityId)) return BadRequest();
            try
            {
                DateTime searchingDate = Convert.ToDateTime(date);
                var currentFlights = _context.Flights.Where(flight =>
                        flight.DepartureTime.Date.Day == searchingDate.Day &&
                        flight.DepartureCity.CityId == departureCityId.ToUpper() &&
                        flight.DestinationCity.Name == destinationCityId.ToUpper())
                    .OrderBy(flight => flight.DepartureTime);
                return Ok(currentFlights);
            }
            catch (FormatException e)
            {
                return BadRequest($"Not correct parameter format: {e.Message}");
            }
            
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }

        // Get Schedule By Flight Id
        [HttpGet("get-schedule-by-flightId")]
        [Produces("application/json")]
        public IActionResult GetSchedule(string flightId)
        {
            if (!Tools.Tools.ContainsAllParameters(flightId)) return BadRequest();
            try
            {
                var currentFlights = _context.Flights.Where(flight =>
                        flight.FlightId == flightId.ToUpper()).Include(flight => flight.DepartureCity)
                    .Include(flight => flight.DestinationCity)
                    .OrderBy(flight => flight.DepartureTime);
                return Ok(currentFlights);
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }
    }
}