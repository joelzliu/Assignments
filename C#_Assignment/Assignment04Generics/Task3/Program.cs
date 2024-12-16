using System;
using Task3;

class Program
{
    static void Main(string[] args)
    {
        GenericRepository<Product> productRepository = new GenericRepository<Product>();

        productRepository.Add(new Product { Id = 1, Name = "Laptop", Price = 1200.50m });
        productRepository.Add(new Product { Id = 2, Name = "Mouse", Price = 25.75m });

        Console.WriteLine("All Products:");
        foreach (var product in productRepository.GetAll())
        {
            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
        }

        Console.WriteLine("\nProduct with ID 2:");
        var singleProduct = productRepository.GetById(2);
        Console.WriteLine($"ID: {singleProduct.Id}, Name: {singleProduct.Name}, Price: {singleProduct.Price}");

        productRepository.Remove(singleProduct);
        Console.WriteLine("\nAfter Removing Product with ID 2:");
        foreach (var product in productRepository.GetAll())
        {
            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
        }

        productRepository.Save();
    }
}