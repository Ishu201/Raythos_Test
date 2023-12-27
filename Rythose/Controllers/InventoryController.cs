using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raythose.DB;
using Raythose.Models;
using Rythose.Models;
using System.Diagnostics;

namespace Rythose.Controllers
{
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext ctx;

        public InventoryController(ApplicationDbContext db)
        {
            this.ctx = db;
        }

        public IActionResult CatReg()
        {
            return View();
        }

        public IActionResult ItemReg()
        {
            return View();
        }

        public IActionResult ItemList()
        {
            IEnumerable<Item> objItemList = ctx.tbl_items
            .Include(item => item.MainCategory)
            .Include(item => item.SubCategory)
            .ToList();

            return View(objItemList);
        }

        public IActionResult CatList()
        {
            ViewBag.MainCategories = ctx.tbl_main_category.ToList();
            ViewBag.SubCategories = ctx.tbl_sub_category.ToList();
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
