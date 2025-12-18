using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Models
{
    public class ProductionOrderRawMaterials
    {
        public ProductionOrder ProductionOrderRawMaterialsId { get; set; }
        public RawMaterial RawMaterialId { get; set; }
        public decimal ConsumedQuantity { get; set; }
    }
}