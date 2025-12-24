using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.BusinessRule
{
    public class InsufficientStockItem
    {
        public string RawMaterialName { get; set; }
        public decimal CurrentStock { get; set; }
        public decimal RequiredQuantity { get; set; }
    }
}