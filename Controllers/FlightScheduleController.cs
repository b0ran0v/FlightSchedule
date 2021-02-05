using System;
using System.Linq;
using FlightSchedule.Data;
using FlightSchedule.Models.Forms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("get-schedule")]
        [Produces("application/json")]
        public IActionResult GetSchedule(string date, string departureCity, string destinationCity)
        {
            if (!Tools.Tools.ContainsAllParameters(date, departureCity, destinationCity)) return BadRequest();
            try
            {
                DateTime searchingDate = Convert.ToDateTime(date);
                var currentFlights = _context.Flights.Where(flight =>
                        flight.DepartureTime.Date.Day == searchingDate.Day &&
                        flight.DepartureCity.Name == departureCity &&
                        flight.DestinationCity.Name == destinationCity)
                    .OrderBy(flight => flight.DepartureTime).Select(flight => new FlightForm
                    {
                        DepartureCity = flight.DepartureCity.Name,
                        DestinationCity = flight.DestinationCity.Name,
                        DepartureTime = flight.DepartureTime,
                        LandingTime = flight.LandingTime
                    });
                return Ok(currentFlights);
            }
            catch (FormatException e)
            {
                return BadRequest($"Not correct parameter format: {e.Message}");
            }
        }
    }
}