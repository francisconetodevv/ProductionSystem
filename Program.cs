using System.Data;
using Microsoft.Data.SqlClient;
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

    RawMaterialRepository repo = new RawMaterialRepository();

    // 1. Insert
    RawMaterial mp = new RawMaterial
    {
        Code = "MP-002",
        RawMaterialName = "Madeira Arueira",
        StockQuantity = 150.0m,
        UOM = "M2"
    };
    repo.InsertRawMaterial(mp);
    Console.WriteLine("✅ Material inserido!\n");

    // 2. GetAll
    var materials = repo.GetAllRawMaterial();
    Console.WriteLine($"📦 Total de materiais: {materials.Count}");
    foreach(var m in materials)
    {
        Console.WriteLine($"  - {m.RawMaterialName}: {m.StockQuantity} {m.UOM}");
    }

    // 3. GetById
    var found = repo.GetRawMaterialById(2);
    if(found != null)
    {
        Console.WriteLine($"\n🔍 Encontrado: {found.RawMaterialName}");
    }

    // 4. Update
    found.StockQuantity = 200.0m;
    found.RawMaterialName = "Madeira MDF Premium";
    repo.UpdateRawMaterial(found);
    Console.WriteLine($"✏️ Material atualizado!\n");

    // Listar novamente para ver mudança
    materials = repo.GetAllRawMaterial();
    Console.WriteLine($"📦 Após update:");
    foreach(var m in materials)
    {
        Console.WriteLine($"  - {m.RawMaterialName}: {m.StockQuantity} {m.UOM}");
    }

    // 5. Delete
    repo.DeleteRawMaterial(2);
    Console.WriteLine($"\n🗑️ Material deletado!");

    materials = repo.GetAllRawMaterial();
    Console.WriteLine($"📦 Total após delete: {materials.Count}");

    Console.WriteLine("\n✅ Todos os testes concluídos!");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Error: {ex.Message}");
}