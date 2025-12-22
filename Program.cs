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
            Console.WriteLine("Connection established with success!");
        }
        

        RawMaterialRepository rawMaterialRepo = new RawMaterialRepository();

        // 1. Testing - Insert
        RawMaterial rawMaterial = new RawMaterial
        {
          Code = "MP-001",
          RawMaterialName = "Madeira MDF",
          StockQuantity = 150.0m,
          UOM = "M2"
        };

        rawMaterialRepo.InsertRawMaterial(rawMaterial);


        // 2. Testing - Read all
        rawMaterialRepo.GetAllRawMaterial();

        // 3. Testing - Read by Id
        rawMaterialRepo.GetRawMaterialById(1);

        // 4.Testing
        
    }

    Console.WriteLine("Connection closed");

}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex}");
}