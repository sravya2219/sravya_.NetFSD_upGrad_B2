using System;
using System.Diagnostics;
using System.IO;

namespace OrderTracingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure Trace Listener (log file)
            Trace.Listeners.Clear();
            TextWriterTraceListener listener = new TextWriterTraceListener("order_log.txt");
            Trace.Listeners.Add(listener);

            // Optional: Auto flush logs immediately
            Trace.AutoFlush = true;

            Console.WriteLine("=== Order Processing Started ===\n");

            try
            {
                ProcessOrder();
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"[ERROR] {ex.Message}");
                Console.WriteLine("Order processing failed. Check logs.");
            }

            Console.WriteLine("\n=== Process Completed ===");
        }

        static void ProcessOrder()
        {
            ValidateOrder();
            ProcessPayment();
            UpdateInventory();
            GenerateInvoice();
        }

        static void ValidateOrder()
        {
            Trace.TraceInformation("[STEP 1] Validating Order...");
            Console.WriteLine("Validating Order...");

            // Simulate logic
            bool isValid = true;

            if (!isValid)
                throw new Exception("Order validation failed");

            Trace.WriteLine("[SUCCESS] Order Validated");
        }

        static void ProcessPayment()
        {
            Trace.TraceInformation("[STEP 2] Processing Payment...");
            Console.WriteLine("Processing Payment...");

            // Simulate failure for debugging
            bool paymentSuccess = true;

            if (!paymentSuccess)
                throw new Exception("Payment failed");

            Trace.WriteLine("[SUCCESS] Payment Processed");
        }

        static void UpdateInventory()
        {
            Trace.TraceInformation("[STEP 3] Updating Inventory...");
            Console.WriteLine("Updating Inventory...");

            // Simulate logic
            Trace.WriteLine("[SUCCESS] Inventory Updated");
        }

        static void GenerateInvoice()
        {
            Trace.TraceInformation("[STEP 4] Generating Invoice...");
            Console.WriteLine("Generating Invoice...");

            // Simulate logic
            Trace.WriteLine("[SUCCESS] Invoice Generated");
        }
    }
}