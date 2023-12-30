using Microsoft.AspNetCore.Mvc;
using Raythose.DB;
using Raythose.Models;
using Rythose.Models;
using System.Diagnostics;

namespace Rythose.Controllers
{
    public class AircraftController : Controller
    {
        private readonly ApplicationDbContext ctx;

        public AircraftController(ApplicationDbContext db)
        {
            this.ctx = db;
        }

        public IActionResult AddAircraft()
        {
            return View();
        }

        public IActionResult AircraftList()
        {
            IEnumerable<Aircraft> objList = ctx.tbl_aircraft.ToList();
            return View(objList);
        }

        public IActionResult CheckBuy(int id)
        {
            ViewBag.Aircraft = ctx.tbl_aircraft.FirstOrDefault(a => a.AircraftId == id);
            ViewBag.MainCategories = ctx.tbl_main_category.ToList();
            ViewBag.SubCategories = ctx.tbl_sub_category.ToList();
            return View();

        }

        

        public IActionResult ListView()
        {
            IEnumerable<Aircraft> objList = ctx.tbl_aircraft.ToList();
            return View(objList);
        }

        public IActionResult SingleDetail(int id)
        {
            Aircraft singleAircraft = ctx.tbl_aircraft.FirstOrDefault(a => a.AircraftId == id);

            if (singleAircraft == null)
            {
                return NotFound();
            }

            return View(singleAircraft);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
