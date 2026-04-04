using System;
using System.Threading.Tasks;

namespace AsyncOrderProcessing
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Order Processing Started ===\n");

            await ProcessOrderAsync();

            Console.WriteLine("\n=== Order Completed Successfully ===");
        }

        // Main workflow method
        static async Task ProcessOrderAsync()
        {
            await VerifyPaymentAsync();
            await CheckInventoryAsync();
            await ConfirmOrderAsync();
        }

        static async Task VerifyPaymentAsync()
        {
            Console.WriteLine("[STEP 1] Verifying Payment...");
            await Task.Delay(2000); // Simulate delay
            Console.WriteLine("[DONE] Payment Verified\n");
        }

        static async Task CheckInventoryAsync()
        {
            Console.WriteLine("[STEP 2] Checking Inventory...");
            await Task.Delay(3000); // Simulate delay
            Console.WriteLine("[DONE] Inventory Available\n");
        }

        static async Task ConfirmOrderAsync()
        {
            Console.WriteLine("[STEP 3] Confirming Order...");
            await Task.Delay(1500); // Simulate delay
            Console.WriteLine("[DONE] Order Confirmed\n");
        }
    }
}