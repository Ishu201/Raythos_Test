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

        public IActionResult CheckBuy()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult ListView()
        {
            return View();
        }

        public IActionResult SingleDetail()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
