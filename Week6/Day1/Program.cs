using System;
using System.Threading.Tasks;

namespace AsyncFileLogger
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Application Started...\n");

            // Simulating multiple log events
            Task log1 = WriteLogAsync("User logged in");
            Task log2 = WriteLogAsync("File uploaded");
            Task log3 = WriteLogAsync("Error occurred");
            Task log4 = WriteLogAsync("User logged out");

            Console.WriteLine("Logs are being written asynchronously...\n");

            // Main thread is still responsive
            Console.WriteLine("Main thread is free to do other work!\n");

            // Wait for all logs to complete
            await Task.WhenAll(log1, log2, log3, log4);

            Console.WriteLine("\nAll logs written successfully!");
        }

        // Asynchronous method to simulate file logging
        static async Task WriteLogAsync(string message)
        {
            Console.WriteLine($"[START] Writing log: {message}");

            // Simulate file writing delay
            await Task.Delay(2000);

            Console.WriteLine($"[END] Log written: {message}");
        }
    }
}