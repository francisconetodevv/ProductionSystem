using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Models
{
    public class ProductionOrderRawMaterials
    {
        public int ProductionOrderId { get; set; }
        public int RawMaterialId { get; set; }
        public decimal ConsumedQuantity { get; set; }
    }
}