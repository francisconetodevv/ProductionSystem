using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ProductionSystem.Data;
using ProductionSystem.Models;

namespace ProductionSystem.Repositories
{
    public class RawMaterialRepository
    {
        public void InsertRawMaterial(RawMaterial rawMaterial)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO RawMaterial VALUES(@Code, @RawMaterialName, @StockQuantity, @UOM)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Code", rawMaterial.Code);
                command.Parameters.AddWithValue("@Code", rawMaterial.RawMaterialName);
                command.Parameters.AddWithValue("@Code", rawMaterial.StockQuantity);
                command.Parameters.AddWithValue("@Code", rawMaterial.UOM);

                command.ExecuteNonQuery();
            }
        }

        public List<RawMaterial> GetAllRawMaterial()
        {
            List<RawMaterial> rawMaterials = new List<RawMaterial>();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM RawMaterial";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    RawMaterial rawMaterial = new RawMaterial
                    {
                        RawMaterialId = (int)reader["RawMaterialId"],
                        Code = reader["Code"].ToString(),
                        RawMaterialName = reader["RawMaterialName"].ToString(),
                        StockQuantity = (decimal)reader["StockQuantity"],
                        UOM = reader["UOM"].ToString()
                    };

                    rawMaterials.Add(rawMaterial);
                }
            }

            return rawMaterials;
        }

        public RawMaterial GetRawMaterialById(int rawMaterialId)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM RawMaterial WHERE RawMaterialId = @RawMaterialId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RawMaterialId", rawMaterialId);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    RawMaterial rawMaterial = new RawMaterial
                    {
                      RawMaterialId = (int)reader["rawMaterialId"],
                      Code = reader["Code"].ToString(),
                      RawMaterialName = reader["RawMaterialName"].ToString(),
                      UOM = reader["UOM"].ToString()
                    };

                    return rawMaterial;
                }

                return null;

            }
        }

        public void UpdateRawMaterial(RawMaterial rawMaterial)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "";

                SqlCommand command = new SqlCommand(query, connection);


            }
        }

        public void DeleteRawMaterial(int rawMaterialId)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "";

                SqlCommand command = new SqlCommand(query, connection);


            }
        }
    }
}