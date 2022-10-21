using Microsoft.AspNetCore.Mvc;

namespace webapp_travel_agency.Controllers
{
    public class GuestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
