using Microsoft.AspNetCore.Mvc;
using Raythose.DB;
using Raythose.Models;
using Rythose.Models;
using System.Diagnostics;

namespace Rythose.Controllers
{
    public class AdminHomeController : Controller
    {
        private readonly ApplicationDbContext ctx;

        public AdminHomeController(ApplicationDbContext db)
        {
            this.ctx = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Aircraft> objList = ctx.tbl_aircraft.ToList();
            return View(objList);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
