using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
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
            //SupportModel support = new();
            PacchettoViaggio voyage = _db.PacchettiViaggio.Include("Destinations").Include("Messages").Where( s => s.Id == id).FirstOrDefault();
            //List<Message> message = _db.Messages.Where(s => s.SmartBoxId == id).ToList();
            //support.PacchettoViaggio = voyage;
            //support.Message = message;
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
            support.PacchettoViaggio = _db.PacchettiViaggio.Include("Destinations").Where(s => s.Id == id).FirstOrDefault();

            return View(support);
        }

        // POST: VoyageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SupportModel formData)
        {
            try
            {
                PacchettoViaggio smartBox = _db.PacchettiViaggio.Find(id);

                smartBox.Name = formData.PacchettoViaggio.Name;
                smartBox.Description = formData.PacchettoViaggio.Description;
                smartBox.StartDate = formData.PacchettoViaggio.StartDate;
                smartBox.Duration = formData.PacchettoViaggio.Duration;
                smartBox.Price = formData.PacchettoViaggio.Price;
                smartBox.Destinations = formData.PacchettoViaggio.Destinations;
                smartBox.Image = formData.PacchettoViaggio.Image;
                
                _db.SaveChanges();
                        
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
        [HttpGet]
        public FileResult Export()
        {
            string[] columnNames = new string[] { "ID", "Name", "StartDate", "Duration", "Description", "Destinations", "Price", "Image" };
            List<PacchettoViaggio> viaggi = _db.PacchettiViaggio.Include("Destinations").ToList();

            string csv = string.Empty;

            foreach (string columnName in columnNames)
            {
                csv += columnName + ',';
            }

            csv += "\r\n";

            foreach(PacchettoViaggio pacchettoViaggio in viaggi)
            {
                csv += pacchettoViaggio.Id.ToString().Replace(",", ";") + ',';
                csv += pacchettoViaggio.Name.Replace(",", ";") + ',';
                csv += pacchettoViaggio.StartDate.ToString(("dd/MM/yyyy HH:mm:ss")).Replace(",", ";") + ',';
                csv += pacchettoViaggio.Duration.ToString().Replace(",", ";") + ',';

                if(pacchettoViaggio.Description != null)
                {
                    csv += pacchettoViaggio.Description.Replace(",", ";") + ',';
                }
                else
                {
                    csv += "" + ',';
                }


                foreach (Destination destination in pacchettoViaggio.Destinations)
                {
                    csv += destination.Name + " & " ;
                }
                csv += ',';
                csv += pacchettoViaggio.Price.ToString().Replace(",", ";") + ',';
                csv += pacchettoViaggio.Image.Replace(",", ";") + ',';

                csv += "\r\n";
            }
            byte[] bytes = Encoding.ASCII.GetBytes(csv);
            return File(bytes, "text/csv", "SmartBox.csv");


        }
    }
}
