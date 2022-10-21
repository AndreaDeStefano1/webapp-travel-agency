using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            List<PacchettoViaggio> voyagies =  _db.PacchettiViaggio.Include("Destinations").ToList();

            return View(voyagies);
        }

        // GET: VoyageController/Details/5
        public ActionResult Details(int id)
        {
            PacchettoViaggio voyage = _db.PacchettiViaggio.Include("Destination").Where( s => s.Id == id).FirstOrDefault();


            return View(voyage);
        }

        // GET: VoyageController/Create
        public ActionResult Create()
        {
            SupportModel support = new();

            support.DestinationsList = _db.Destinations.ToList();

            return View(support);
        }

        // POST: VoyageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupportModel voyage)
        {
            try
            {
                PacchettoViaggio smartBox = new();
                smartBox = voyage.PacchettoViaggio;
                List<Destination> destinations = _db.Destinations.ToList();
                smartBox.Destinations = new();
                foreach (Destination destination in destinations)
                {
                    if (voyage.DestinationsIds.Contains(destination.Id))
                    {
                        
                        
                        smartBox.Destinations.Add(destination);
                    }
                }
                _db.PacchettiViaggio.Add(smartBox);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                

                voyage.DestinationsList = _db.Destinations.ToList();

                return View(voyage);
            }
        }

        // GET: VoyageController/Edit/5
        public ActionResult Edit(int id)
        {
            SupportModel support = new();

            support.DestinationsList = _db.Destinations.ToList();
            support.PacchettoViaggio = _db.PacchettiViaggio.Include("Destination").Where(s => s.Id == id).FirstOrDefault();

            return View(support);
        }

        // POST: VoyageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SupportModel formData)
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
           
                PacchettoViaggio smartBox = _db.PacchettiViaggio.Find(id);

                _db.PacchettiViaggio.Remove(smartBox);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
        }
    }
}
