using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
    [Route("api/[controller]")]
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
        
        [HttpPost("addFlight")]
        public async Task<IActionResult> AddFlight()
        {
            try
            {
                var message = await (new StreamReader(Request.Body)).ReadToEndAsync();
                var flightForm = JsonConvert.DeserializeObject<FlightForm>(message);
                Flight flight = new Flight
                {
                    DepartureTime = flightForm.DepartureTime,
                    LandingTime = flightForm.LandingTime,
                    DepartureCity = await _context.Cities.
                        FirstOrDefaultAsync(city=>city.Name==flightForm.DepartureCity),
                    DestinationCity = await _context.Cities.
                        FirstOrDefaultAsync(city=>city.Name==flightForm.DestinationCity),
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
    }
}