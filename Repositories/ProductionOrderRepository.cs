using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ProductionSystem.Data;
using ProductionSystem.Models;

namespace ProductionSystem.Repositories
{
    public class ProductionOrderRepository
    {
        // INSERT
        public void InsertProductionOrder(int productId, decimal quantityToProduce, List<ProductionOrderRawMaterials> materials)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string orderNumber = "OP-" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
                string query = "INSERT INTO ProductionOrder (OrderNumber, ProductId, QuantityToProduce, CreationDate, OrderStatus) VALUES (@OrderNumber, @ProductId, @QuantityToProduce, @CreationDate, @OrderStatus); SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@OrderNumber", orderNumber);
                command.Parameters.AddWithValue("@ProductId", productId);
                command.Parameters.AddWithValue("@QuantityToProduce", quantityToProduce);
                command.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                command.Parameters.AddWithValue("@OrderStatus", "Aberta");

                object result = command.ExecuteScalar();
                int productionOrderId = Convert.ToInt32(result);

                if(materials != null && materials.Count != 0)
                {
                    string queryValue = "INSERT INTO ProductionOrderRawMaterials (ProductionOrderId, RawMaterialId, ConsumedQuantity) VALUES (@ProductionOrderId, @RawMaterialId, @ConsumedQuantity)";
                    
                    foreach(var item in materials)
                    {
                        SqlCommand commandMaterials = new SqlCommand(queryValue, connection);

                        commandMaterials.Parameters.AddWithValue("@ProductionOrderId", productionOrderId);
                        commandMaterials.Parameters.AddWithValue("@RawMaterialId", item.RawMaterialId);
                        commandMaterials.Parameters.AddWithValue("@ConsumedQuantity", item.ConsumedQuantity);

                        commandMaterials.ExecuteNonQuery();
                    }
                }
            }
        }

        // GET

        // GET BY ID

        // UPDATE

        // DELETE

    }
}