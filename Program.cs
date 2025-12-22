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
        
    }

    Console.WriteLine("Connection closed");

}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex}");
}