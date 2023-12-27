using Microsoft.EntityFrameworkCore;
using Raythose.DB;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Raythose.Models
{
    public class EssentialItems 
    {
        [Key]
        public int EssentialId { get; set; }

        [MaxLength(20)]
        public string EssentialType { get; set; }

        [MaxLength(100)]
        public string EssentialName { get; set; }

        public int EssentialQuantity { get; set; }

        [MaxLength(20)]
        public string EssentialDate { get; set; }

        public int EssentialStock { get; set; }


        /*public List<(int essential_id, string ess_name)> GetItemsByEssentialType(ApplicationDbContext context, string essType)
        {
            
            try
            {
                var results = context.tbl_essential_items
                .FromSqlRaw($"SELECT essential_id, ess_name FROM tbl_essential_items WHERE ess_stock > 0 AND ess_type='{essType}'")
                .Select(result => new ValueTuple<int, string>(result.essential_id, result.ess_name))
                .ToList();


                return results ?? new List<(int essential_id, string ess_name)>(); // Handle null if necessary
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Handle the exception according to your application's needs
                return new List<(int essential_id, string ess_name)>(); // or throw an exception
            }

        }*/



    }
}
