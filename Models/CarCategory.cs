using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beci_Helga_Proiect.Models
{
    public class CarCategory
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
