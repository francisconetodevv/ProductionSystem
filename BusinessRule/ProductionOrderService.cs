using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductionSystem.Models;
using ProductionSystem.Repositories;

namespace ProductionSystem.BusinessRule
{
    public class ProductionOrderService
    {

        private StockValidator _stockValidator;
        private ProductionOrderRepository _productionOrderRepository;

        public ProductionOrderService()
        {
            _stockValidator = new StockValidator();
            _productionOrderRepository = new ProductionOrderRepository();
        }

        public bool CreateProductionOrder(int productId, decimal quantityToProduce, List<ProductionOrderRawMaterials> materials)
        {
            StockValidationResult result = _stockValidator.CheckStock(materials);

            if (!result.IsValid)
            {
                Console.WriteLine("Não é possível criar ordem. Estoque Insuficiente: \n");

                foreach (var item in result.InsufficientItems)
                {
                    Console.WriteLine($"  • {item.RawMaterialName}:");
                    Console.WriteLine($"    - Estoque atual: {item.CurrentStock}");
                    Console.WriteLine($"    - Quantidade necessária: {item.RequiredQuantity}");
                    Console.WriteLine($"    - Faltam: {item.RequiredQuantity - item.CurrentStock}\n");
                }

                return false;
            }

            _productionOrderRepository.InsertProductionOrder(productId, quantityToProduce, materials);

            Console.WriteLine("Ordem de produção criada com sucesso!");
            return true;
        }
    }
}