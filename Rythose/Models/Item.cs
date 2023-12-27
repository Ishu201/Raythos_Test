using Microsoft.EntityFrameworkCore;
using Raythose.DB;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raythose.Models
{
    public class Item 
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [MaxLength(150)]
        public string ItemName { get; set; }

        [Required]
        public int MainId { get; set; }

        [Required]
        public int SubId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        [MaxLength(100)]
        public string Vendor { get; set; }

        [Required]
        [MaxLength(1)]
        public string Date { get; set; }

        [Required]
        [MaxLength(20)]
        public string Stock { get; set; } = "active";

        [ForeignKey("MainId")]
        public MainCategory MainCategory { get; set; }

        [ForeignKey("SubId")]
        public SubCategory SubCategory { get; set; }


        /*public List<Item> GetAllItems(ApplicationDbContext context)
        {
            try
            {
                var items = context.tbl_items
                    .FromSqlRaw("SELECT * FROM tbl_items")
                    .ToList();

                return items ?? new List<Item>(); // Handle null if necessary
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Handle the exception according to your application's needs
                return new List<Item>(); // or throw an exception
            }
        }



        public List<(int item_id, string item_name)> GetSelectedItems(ApplicationDbContext context, int mainId)
        {
            
            try
            {
                var items = context.tbl_items
                    .FromSqlRaw("SELECT item_id, item_name FROM tbl_items WHERE main_id = {mainId}")
                    .Select(result => new ValueTuple<int, string>(result.item_id, result.item_name))
                    .ToList();

                return items ?? new List<(int item_id, string item_name)>(); // Handle null if necessary
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Handle the exception according to your application's needs
                return new List<(int item_id, string item_name)>(); // or throw an exception
            }
        }


        public List<(int item_id, string item_name)> GetEntertainmentItemDetails(ApplicationDbContext context)
        {
            try
            {
                var items = context.tbl_items
                    .FromSqlRaw("SELECT item_id, item_name FROM tbl_items WHERE main_id = '4'")
                    .Select(result => new ValueTuple<int, string>(result.item_id, result.item_name))
                    .ToList();

                return items ?? new List<(int item_id, string item_name)>(); // Handle null if necessary
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Handle the exception according to your application's needs
                return new List<(int item_id, string item_name)>(); // or throw an exception
            }
        }*/




    }
}
