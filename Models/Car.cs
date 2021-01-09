using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beci_Helga_Proiect.Models
{
    public class Car
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 2)]
        [Display(Name = "Car Brand")]
        public string Brand { get; set; }
        public string Type { get; set; }
        [Range(900, 9999)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime SellingDate { get; set; }

        public int SellerID { get; set; }
        public Seller Seller { get; set; }
        public ICollection<CarCategory> CarCategories { get; set; }
    }
}
