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

        Product product = new Product{
            Code = "PROD-005",
            ProductName = "Mesa Escritório",
            ProductDescription = "Mesa de Escritório Basic",
            UOM = "UN"
        };

        ProductRepository productRepository = new ProductRepository();
        productRepository.InsertProduct(product);

        Console.WriteLine($"The product was inserted with success {product.ProductName}");
        Console.WriteLine("All products in the database: ");
        
        List<Product> products = productRepository.GetAllProducts();

        foreach(var value in products)
        {
            Console.WriteLine($"ID: {value.ProductId} | Code: {value.Code} | Name: {value.ProductName}");
        }

        Console.WriteLine("Getting only the product that has ID equal to 3.");
        Product productThree = productRepository.GetProductById(3);

        if (productThree != null)
        {
            Console.WriteLine("Product three found it!");
            Console.WriteLine($"ID: {productThree.ProductId}");
            Console.WriteLine($"Code: {productThree.Code}");
            Console.WriteLine($"Name: {productThree.ProductName}");
            Console.WriteLine($"Description: {productThree.ProductDescription}");
            Console.WriteLine($"UOM: {productThree.UOM}");
        } else
        {
            Console.WriteLine("Produto não encontrado!");
        }

        Product productFour = new Product{
            ProductId = 3,
            Code = "PROD-005",
            ProductName = "Mesa Escritório",
            ProductDescription = "Mesa de Escritório Basic",
            UOM = "UN"
        };

        productRepository.UpdateProduct(productFour);

        List<Product> productsFive = productRepository.GetAllProducts();

        foreach(var value in productsFive)
        {
            Console.WriteLine($"ID: {value.ProductId} | Code: {value.Code} | Name: {value.ProductName}");
        }
        
    }

    Console.WriteLine("Connection closed");

}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex}");
}