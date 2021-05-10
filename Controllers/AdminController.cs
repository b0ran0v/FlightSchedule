using System;
using System.IO;
using System.Threading.Tasks;
using FlightSchedule.Data;
using FlightSchedule.Models;
using FlightSchedule.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FlightSchedule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<FlightScheduleController> _logger;
        private readonly ApplicationDbContext _context;

        public AdminController(ILogger<FlightScheduleController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Welcome to Admin Page!");
        }

        // Create new flight
        [HttpPost("add-flight")]
        public async Task<IActionResult> AddFlight()
        {
            try
            {
                var message = await new StreamReader(Request.Body).ReadToEndAsync();
                var flightForm = JsonConvert.DeserializeObject<FlightForm>(message);
                Flight flight = new Flight
                {
                    FlightId = flightForm.FlightId,
                    DepartureTime = flightForm.DepartureTime,
                    LandingTime = flightForm.LandingTime,
                    DepartureCity =
                        await _context.Cities.FirstOrDefaultAsync(city => city.CityId == flightForm.DepartureCityId),
                    DestinationCity =
                        await _context.Cities.FirstOrDefaultAsync(city => city.CityId == flightForm.DestinationCityId),
                };
                await _context.AddAsync(flight);
                await _context.SaveChangesAsync();
                return Ok("New flight is successfully added.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // Remove by flightId
        [HttpDelete("delete-flight")]
        public async Task<IActionResult> RemoveFlight(string flightId)
        {
            if (!Tools.Tools.ContainsAllParameters(flightId)) return BadRequest();
            try
            {
                Flight flight = new Flight { FlightId = flightId };
                _context.Attach(flight);
                _context.Remove(flight);
                await _context.SaveChangesAsync();
                return Ok("Flight is successfully removed");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Update by Flight Id
        [HttpPut("update-flight")]
        public async Task<IActionResult> UpdateFlight(string flightId)
        {
            if (!Tools.Tools.ContainsAllParameters(flightId)) return BadRequest();
            try
            {
                var message = await new StreamReader(Request.Body).ReadToEndAsync();
                var flightForm = JsonConvert.DeserializeObject<FlightUpdateForm>(message);
                Flight flight = new Flight { FlightId = flightId };
                
                //Finding specific flight in context
                _context.Attach(flight);
                
                //Changing values of departure and landing time of flight
                flight.DepartureTime = flightForm.DepartureTime;
                flight.LandingTime = flightForm.LandingTime;
                
                //Saving changes
                await _context.SaveChangesAsync();
                return Ok("Flight is successfully updated");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}