using Microsoft.AspNetCore.Mvc;
using Raythose.DB;
using Raythose.Models;
using Rythose.Models;
using System.Diagnostics;

namespace Rythose.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext ctx;

        public CustomerController(ApplicationDbContext db)
        {
            this.ctx = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomerProfile()
        {
            return View();
        }

        public IActionResult OwnAircrafts()
        {
            return View();
        }

        public IActionResult OrderHistory()
        {
            return View();
        }

        public IActionResult OwnedSingle()
        {
            return View();
        }

        public IActionResult CusList()
        {
            IEnumerable<Customer> objList = ctx.tbl_customer.ToList();
            return View(objList);
        }

        public IActionResult CusPref()
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
