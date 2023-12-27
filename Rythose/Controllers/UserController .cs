using Microsoft.AspNetCore.Mvc;
using Raythose.DB;
using Raythose.Models;
using Rythose.Models;
using System.Diagnostics;

namespace Rythose.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext ctx;

        public UserController(ApplicationDbContext db)
        {
            this.ctx = db;
        }

        public IActionResult Index()
        {
            IEnumerable<User> objList = ctx.tbl_user.ToList();
            return View(objList);
        }

        public IActionResult Add()
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
