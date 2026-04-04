using System;

namespace DiscountDebugger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Product Discount Calculator ===");

            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Discount Percentage: ");
            double discount = Convert.ToDouble(Console.ReadLine());

            //Breakpoint
            double discountAmount = price * discount / 100;

            // Breakpoint
            double finalPrice = price - discountAmount;

            Console.WriteLine("\n--- Result ---");
            Console.WriteLine($"Product: {productName}");
            Console.WriteLine($"Original Price: {price}");
            Console.WriteLine($"Discount: {discount}%");
            Console.WriteLine($"Final Price: {finalPrice}");
        }
    }
}