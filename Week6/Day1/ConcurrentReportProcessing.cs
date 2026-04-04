using System;
using System.Threading;
using System.Threading.Tasks;

namespace ReportProcessingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Report Processing Started ===\n");

            // Run tasks concurrently
            Task salesTask = Task.Run(() => GenerateSalesReport());
            Task inventoryTask = Task.Run(() => GenerateInventoryReport());
            Task customerTask = Task.Run(() => GenerateCustomerReport());

            // Wait for all tasks to complete
            Task.WaitAll(salesTask, inventoryTask, customerTask);

            Console.WriteLine("\n=== All Reports Generated Successfully ===");
        }

        static void GenerateSalesReport()
        {
            Console.WriteLine("[START] Sales Report Generation...");
            Thread.Sleep(3000); // Simulate processing time
            Console.WriteLine("[END] Sales Report Completed!");
        }

        static void GenerateInventoryReport()
        {
            Console.WriteLine("[START] Inventory Report Generation...");
            Thread.Sleep(4000); // Simulate processing time
            Console.WriteLine("[END] Inventory Report Completed!");
        }

        static void GenerateCustomerReport()
        {
            Console.WriteLine("[START] Customer Report Generation...");
            Thread.Sleep(2000); // Simulate processing time
            Console.WriteLine("[END] Customer Report Completed!");
        }
    }
}