using System.Data;
using Microsoft.Data.SqlClient;
using ProductionSystem.BusinessRule;
using ProductionSystem.Data;
using ProductionSystem.Models;
using ProductionSystem.Repositories;

try
{
    using (SqlConnection connection = DatabaseConnection.GetConnection())
    {
        if (connection.State == ConnectionState.Open)
        {
            Console.WriteLine("Connection established with success!\n");
        }
    }

    StockValidator validator = new StockValidator();

    // Cenário de Estoque válido:
    Console.WriteLine("--- CENÁRIO 1: Estoque Suficiente ---");

    List<ProductionOrderRawMaterials> testSuccess = new List<ProductionOrderRawMaterials>()
    {
      new ProductionOrderRawMaterials
      {
            RawMaterialId = 4,
            ConsumedQuantity = 50
      }
    };

    StockValidationResult resultSuccess = validator.CheckStock(testSuccess);
    Console.WriteLine($"Validação: {(resultSuccess.IsValid ? "Aprovado" : "Reprovado")}");
    Console.WriteLine($"Problemas encontrados: {resultSuccess.InsufficientItems.Count}");

    Console.Clear();

    // Cenário de Estoque Inválido
    Console.WriteLine("--- CENÁRIO 2: Estoque Insuficiente ---");
    List<ProductionOrderRawMaterials> testFail = new List<ProductionOrderRawMaterials>()
    {
        new ProductionOrderRawMaterials
        {
            RawMaterialId = 6,
            ConsumedQuantity = 50
        },

        new ProductionOrderRawMaterials
        {
            RawMaterialId = 8,
            ConsumedQuantity = 30
        }
    };

    StockValidationResult resultFail = validator.CheckStock(testFail);
    Console.WriteLine($"Validação: {(resultFail.IsValid ? "Aprovado" : "Reprovado")}");
    Console.WriteLine($"Problemas encontrados: {resultFail.InsufficientItems.Count}");

    if (!resultFail.IsValid)
    {
        Console.WriteLine("\nDetalhes dos problemas: ");
        foreach (var item in resultFail.InsufficientItems)
        {
            Console.WriteLine($"  • {item.RawMaterialName}:");
            Console.WriteLine($"    - Estoque atual: {item.CurrentStock}");
            Console.WriteLine($"    - Quantidade necessária: {item.RequiredQuantity}");
            Console.WriteLine($"    - Faltam: {item.RequiredQuantity - item.CurrentStock}\n");
        }
    }

    Console.WriteLine("========== FIM DO TESTE ==========\n");

}
catch (Exception ex)
{
    Console.WriteLine($"❌ Error: {ex.Message}");
}