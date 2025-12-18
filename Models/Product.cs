using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string UOM { get; set; }

    }
}