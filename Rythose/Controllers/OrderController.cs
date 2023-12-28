using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Raythose.DB;
using Raythose.Models;
using Rythose.Models;
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
            List<Order> orders = ctx.tbl_order
            .Include(item => item.Aircraft)
            .Include(item => item.Customer)
            .Include(item => item.SeatingOption)
            .Include(item => item.InteriorDesign)
            .Include(item => item.ConnectivityOption)
            .Include(item => item.EntertainmentOption)
            .Where(item => item.OrderStatus == "no progress" && item.PaymentStatus == "Paid")
            .ToList();

            return View(orders);
        }

        public IActionResult start_manufacture(int id)
        {
            Order orderItem = ctx.tbl_order
        .Include(item => item.Aircraft)
        .Include(item => item.Customer)
        .Include(item => item.SeatingOption)
        .Include(item => item.InteriorDesign)
        .Include(item => item.ConnectivityOption)
        .Include(item => item.EntertainmentOption)
        .FirstOrDefault(item => item.OrderId == id);

            if (orderItem == null)
            {
                return NotFound();
            }

            // Fetch the lists of items from tbl_items for different categories
            List<Item> seatingItemList = ctx.tbl_items.Where(item => item.SubId == orderItem.Seating).ToList();
            List<Item> entertainmentItemList = ctx.tbl_items.Where(item => item.SubId == orderItem.Entertainment).ToList();
            List<Item> interiorItemList = ctx.tbl_items.Where(item => item.SubId == orderItem.Interior).ToList();
            List<Item> ConnectivityItemList = ctx.tbl_items.Where(item => item.SubId == orderItem.Connectivity).ToList();

            // Fetch the lists of essential items for different types
            List<EssentialItems> airframeItemList = ctx.tbl_essential_items
                .Where(item => item.EssentialType == "Airframe" && item.EssentialStock > 0)
                .ToList();
            List<EssentialItems> powerplantItemList = ctx.tbl_essential_items
                .Where(item => item.EssentialType == "Powerplant" && item.EssentialStock > 0)
                .ToList();
            List<EssentialItems> avionicsItemList = ctx.tbl_essential_items
                .Where(item => item.EssentialType == "Avionics" && item.EssentialStock > 0)
                .ToList();
            List<EssentialItems> miscellaneousItemList = ctx.tbl_essential_items
                .Where(item => item.EssentialType == "Miscellaneous" && item.EssentialStock > 0)
                .ToList();


            // Create an instance of the view model and set its properties
            OrderViewModel viewModel = new OrderViewModel
            {
                Order = orderItem,
                Aircraft = orderItem.Aircraft,
                SeatingOption = orderItem.SeatingOption,
                InteriorDesign = orderItem.InteriorDesign,
                ConnectivityOption = orderItem.ConnectivityOption,
                EntertainmentOption = orderItem.EntertainmentOption,
                SeatingItemList = new SelectList(seatingItemList, "ItemId", "ItemName"),
                EntertainmentItemList = new SelectList(entertainmentItemList, "ItemId", "ItemName"),
                InteriorItemList = new SelectList(interiorItemList, "ItemId", "ItemName"),
                ConnectivityItemList = new SelectList(ConnectivityItemList, "ItemId", "ItemName"),
                AirframeItemList = new SelectList(airframeItemList, "EssentialId", "EssentialName"),
                PowerplantItemList = new SelectList(powerplantItemList, "EssentialId", "EssentialName"),
                AvionicsItemList = new SelectList(avionicsItemList, "EssentialId", "EssentialName"),
                MiscellaneousItemList = new SelectList(miscellaneousItemList, "EssentialId", "EssentialName")
            };


            // Pass the view model to the view
            return View(viewModel);
        }



        public IActionResult manufacture_list()
        {
            List<Order> orders = ctx.tbl_order
            .Include(item => item.Aircraft)
            .Include(item => item.Customer)
            .Include(item => item.Manufacture)
            .Where(item => item.OrderStatus == "Manufacturing")
            .ToList();

            return View(orders);
        }

        public IActionResult start_shipment(int id)
        {
            Order orderItem = ctx.tbl_order
                .Include(item => item.Aircraft)
                .Include(item => item.Customer)
                .FirstOrDefault(item => item.OrderId == id);

            return View(orderItem);
        }

        public IActionResult shipping_list()
        {
            List<Order> orders = ctx.tbl_order
            .Include(item => item.Aircraft)
            .Include(item => item.Customer)
            .Where(item => item.OrderStatus == "Dispatched" || item.OrderStatus == "Shipped" || item.OrderStatus == "Local Country")
            .ToList();

            return View(orders);
        }

        public IActionResult completed_list()
        {
            List<Order> orders = ctx.tbl_order
            .Include(item => item.Aircraft)
            .Include(item => item.Customer)
            .Include(item => item.SeatingOption)
            .Include(item => item.InteriorDesign)
            .Include(item => item.ConnectivityOption)
            .Include(item => item.EntertainmentOption)
            .Where(item => item.OrderStatus == "Completed")
            .ToList();

            return View(orders);
        }

        public IActionResult Invoice(int id)
        {
            Order order = ctx.tbl_order
                .Include(item => item.Aircraft)
                .Include(item => item.Customer)
                .Include(item => item.Manufacture)
                .FirstOrDefault(item => item.OrderId == id);

            if (order == null)
            {
                // Handle the case where no order with the specified id is found
                return NotFound();
            }

            return View(order);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
