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
            StockValidationResult stockValidationResult = new StockValidationResult();

            foreach (var material in materials)
            {
                var rawMaterial = _rawMaterialRepository.GetRawMaterialById(material.RawMaterialId);

                if (rawMaterial.StockQuantity < material.ConsumedQuantity)
                {
                    InsufficientStockItem insufficientStockItem = new InsufficientStockItem
                    {
                        RawMaterialName = rawMaterial.RawMaterialName,
                        CurrentStock = rawMaterial.StockQuantity,
                        RequiredQuantity = material.ConsumedQuantity
                    };

                    stockValidationResult.InsufficientItems.Add(insufficientStockItem);

                }
            }

            if (stockValidationResult.InsufficientItems.Count == 0)
            {
                stockValidationResult.IsValid = true;
            }
            else
            {
                stockValidationResult.IsValid = false;
            }

            return stockValidationResult;
        }
    }
}