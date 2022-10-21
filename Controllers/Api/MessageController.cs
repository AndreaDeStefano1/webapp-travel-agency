using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        VoyageContext _db;
        public MessageController()
        {
            _db = new VoyageContext();
        }

        


        

        public IActionResult Post( Message message)
        {
            _db.Messages.Add(message);
            _db.SaveChanges();
            return Ok();
        }
    }
}
