using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.BusinessRule
{
    public class StockValidationResult
    {
        public bool Passed { get; set; }
        public List<InsufficientStockItem> InsufficientStockItemsList { get; set; }

        public StockValidationResult()
        {
            InsufficientStockItemsList = new List<InsufficientStockItem>();
        }
    }
}