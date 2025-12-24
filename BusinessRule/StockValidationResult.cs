using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.BusinessRule
{
    public class StockValidationResult
    {
        public bool IsValid { get; set; }
        public List<InsufficientStockItem> InsufficientItems { get; set; }

        public StockValidationResult()
        {
            InsufficientItems = new List<InsufficientStockItem>();
        }
    }
}