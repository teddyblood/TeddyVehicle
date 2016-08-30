using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcVehicle.Data;
using MvcVehicle.Models;

namespace MvcVehicle.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiclesController(ApplicationDbContext context)
        {
            _context = context;    
        }

 /*       // GET: Vehicles
        public async Task<IActionResult> Index(string searchString)
        {
            var vehicles = from p in _context.Vehicle
                           select p;

            if(!String.IsNullOrEmpty(searchString))
            {
                vehicles = vehicles.Where(k => k.CarModel.Contains(searchString));
            }
            return View(await vehicles.ToListAsync());
        }
 */
        public async Task<IActionResult> Index(string carMakersearch, string searchstring)
        {
            // Use LINQ to get list of makers
            IQueryable<string> makerQuery = from z in _context.Vehicle
                                            orderby z.Maker
                                            select z.Maker;
            var vehicles = from z in _context.Vehicle
                           select z;

            if (!String.IsNullOrEmpty(searchstring))
            {
                vehicles = vehicles.Where(m => m.CarModel.Contains(searchstring));              
            }

            if (!String.IsNullOrEmpty(carMakersearch))
            {
                vehicles = vehicles.Where(j => j.Maker == carMakersearch);
            }

            var carModelVM = new CarMakerViewModel();
            carModelVM.makers = new SelectList(await makerQuery.Distinct().ToListAsync());
            carModelVM.vehicles = await vehicles.ToListAsync();

            return View(carModelVM);
        }




        // POST: Vehicles    
        [HttpPost]
        public string Index(string searchString, bool notused)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }



        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.SingleOrDefaultAsync(m => m.ID == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }



        // GET: Vehicles/Create
        public IActionResult Create()
        {
            return View();
        }
                
        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CarModel,EGsize,Maker,SOP")] Vehicle vehicle)
        {

/*            //Validate Google recaptcha here
            var response = Request["g-recaptcha-response"];
            string secretKey = "6LclxSgTAAAAANWxsVaVQVEKis_-rEuHi4ChpKDK";
            var result = DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = Newtonsoft.Json.Linq.JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");


            //When you will post form for save data, you should check both the model validation and google recaptcha validation
            //EX.
            /* if (ModelState.IsValid && status)
            {

            }*/

            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }



        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.SingleOrDefaultAsync(m => m.ID == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CarModel,EGsize,Maker,SOP,Transmission,Hybrid")] Vehicle vehicle)
        {
            if (id != vehicle.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }



        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.SingleOrDefaultAsync(m => m.ID == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }


        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicle.SingleOrDefaultAsync(m => m.ID == id);
            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.ID == id);
        }
    }
}
