using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Models
{
    public class ProductionOrder
    {
        public int ProductionOrderId { get; set; }
        public string OrderNumber { get; set; }
        public int ProductId { get; set; }
        public decimal QuantityToProduce { get; set; }
        public DateTime CreationDate { get; set; }
        public string OrderStatus { get; set; }
    }
}