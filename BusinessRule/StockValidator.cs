using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductionSystem.Models;
using ProductionSystem.Repositories;

namespace ProductionSystem.BusinessRule
{
    public class StockValidator
    {
        private RawMaterialRepository _rawMaterialRepository = new RawMaterialRepository();

        public StockValidationResult CheckStock(List<ProductionOrderRawMaterials> materials)
        {
            throw new NotImplementedException();
        }
    }
}