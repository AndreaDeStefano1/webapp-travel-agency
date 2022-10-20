using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        VoyageContext _db;
        public GuestController()
        {
            _db = new VoyageContext();
        }

        [HttpGet]
        public IActionResult Get(string? name)
        {
            IQueryable<PacchettoViaggio> smartBoxes;
            if (name != null)
            {
                name = name.ToLower();
                smartBoxes = _db.PacchettiViaggio.Where(s => s.Name.ToLower().Contains(name.ToLower())).Include("Destination");
                return Ok(smartBoxes.ToList());
            }
            else
            {
                smartBoxes = _db.PacchettiViaggio.Include("Destination");
                return Ok(smartBoxes.ToList());
            }


        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IQueryable<PacchettoViaggio> smartBoxes = _db.PacchettiViaggio.Where(s => s.Id == id).Include("Destination");
            return Ok(smartBoxes.FirstOrDefault());
        }
    }
}
