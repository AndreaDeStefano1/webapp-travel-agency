using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    [Authorize]
    public class VoyageController : Controller
    {
        VoyageContext _db;

        public VoyageController()
        {
            _db = new VoyageContext();  
        }

        // GET: VoyageController
        public ActionResult Index()
        {
            List<PacchettoViaggio> voyagies =  _db.PacchettiViaggio.ToList();

            return View(voyagies);
        }

        // GET: VoyageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VoyageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VoyageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VoyageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VoyageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VoyageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VoyageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
