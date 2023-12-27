using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raythose.DB;
using Raythose.Models;
using Rythose.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Rythose.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext ctx;

        public OrderController(ApplicationDbContext db)
        {
            this.ctx = db;
        }

        public IActionResult order_list()
        {
            IEnumerable<Order> objOrderList = ctx.tbl_order.ToList();
            return View(objOrderList);
        }

        public IActionResult start_manufacture(int id)
        {
            // Execute SQL query for Essentials
            /*EssentialItems airframe = new EssentialItems();
            List<(int essential_id, string ess_name)> airframe_data = airframe.GetItemsByEssentialType(ctx, "Airframe");

            EssentialItems powerplant = new EssentialItems();
            List<(int essential_id, string ess_name)> powerplant_data = powerplant.GetItemsByEssentialType(ctx, "Powerplant");

            EssentialItems avionics = new EssentialItems();
            List<(int essential_id, string ess_name)> avionics_data = avionics.GetItemsByEssentialType(ctx, "Avionics");

            EssentialItems misc = new EssentialItems();
            List<(int essential_id, string ess_name)> misc_data = misc.GetItemsByEssentialType(ctx, "Miscellaneous");

            ViewData["airframe"] = airframe_data;
            ViewData["powerplant"] = powerplant_data;
            ViewData["avionics"] = avionics_data;
            ViewData["misc"] = misc_data;

            
                // Execute SQL query for Other Items
                Item seating_ob = new Item();
                List<(int item_id, string item_name)> seating_ob_data = seating_ob.GetSelectedItems(ctx, 1);
                ViewData["seating_data"] = seating_ob_data;

                Item interior_ob = new Item();
                List<(int item_id, string item_name)> interior_ob_data = seating_ob.GetSelectedItems(ctx, 2);
                ViewData["interior_data"] = interior_ob_data;

                Item connectivity_ob = new Item();
                List<(int item_id, string item_name)> connectivity_ob_data = connectivity_ob.GetSelectedItems(ctx, 3);
                ViewData["connectivity_data"] = connectivity_ob_data;

                Item entertaintment_ob = new Item();
                List<(int item_id, string item_name)> entertaintment_ob_data = entertaintment_ob.GetSelectedItems(ctx, 4);
                ViewData["entertaintment_data"] = entertaintment_ob_data;
            */
            
            return View();
        }



        public IActionResult manufacture_list()
        {
            return View();
        }

        public IActionResult start_shipment()
        {
            return View();
        }

        public IActionResult shipping_list()
        {
            return View();
        }

        public IActionResult completed_list()
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
