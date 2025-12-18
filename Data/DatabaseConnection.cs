using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ProductionSystem.Data
{
    public class DatabaseConnection
    {
        // This class has the objetive to save the connection string with the database
        // And stablish the connection into the database
        // To use this class it is necessary to instantiate SqlConnection
        private static readonly string ConnectionString = "Server=DESKTOP-1H81HKV\\DBDEVELOPER;Database=ProductionControlDB;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();
            
            return connection;
        }
    }
}