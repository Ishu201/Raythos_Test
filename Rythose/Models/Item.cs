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
        public int Stock { get; set; } 

        [ForeignKey("MainId")]
        public MainCategory MainCategory { get; set; }

        [ForeignKey("SubId")]
        public SubCategory SubCategory { get; set; }




    }
}
