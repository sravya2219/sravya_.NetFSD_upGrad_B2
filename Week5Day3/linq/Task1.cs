using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.linq
{
    internal class Task1
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            var result1=products.Where(p => p.ProCategory == "FMCG").ToList();
            foreach(var p in result1)
            {
                Console.WriteLine($"code: {p.ProCode}\n Name:{p.ProName}\n MRP: {p.ProMrp}");
            }
            Console.WriteLine("----------------------------------");
            var result2 = products.Where(p => p.ProCategory == "Grain");
            foreach(var p in result2)
            {
                Console.WriteLine($"code: {p.ProCode}\n Name:{p.ProName}\n MRP: {p.ProMrp}");
            }
            Console.WriteLine("----------------------------------");
            var result3 = products.OrderBy(p => p.ProCode).ToList();
            foreach(var p in result3)
            {
                Console.WriteLine($"code: {p.ProCode}\n Name:{p.ProName}\n ProCategory:{p.ProCategory}\n MRP: {p.ProMrp}");
            }
            Console.WriteLine("----------------------------------");
            var result4 = products.OrderBy(p => p.ProMrp).ToList();

            foreach (var p in result4)
            {
                Console.WriteLine($"code: {p.ProCode}\n Name:{p.ProName}\n ProCategory:{p.ProCategory}\n MRP: {p.ProMrp}");
            }
            Console.WriteLine("----------------------------------");
            var result5 = products.OrderByDescending(p => p.ProMrp).ToList();
            foreach (var p in result5)
            {
                Console.WriteLine($"code: {p.ProCode}\n Name:{p.ProName}\n ProCategory:{p.ProCategory}\n MRP: {p.ProMrp}");
            }
            Console.WriteLine("----------------------------------");
            var result6 = products.GroupBy(p => p.ProCategory).ToList();

            foreach (var group in result6)
            {
                Console.WriteLine($"category: {group.Key}");
                foreach(var p in group)
                {
                    Console.WriteLine($"code: {p.ProCode}\n Name:{p.ProName}\n MRP: {p.ProMrp}");
                }
                Console.WriteLine();
              
            }
            Console.WriteLine("------------------------------------------");
            var result7 = products.GroupBy(p => p.ProMrp).ToList();

            foreach (var group in result7)
            {
                Console.WriteLine($"mrp code : {group.Key}");
                foreach (var p in group)
                {
                    Console.WriteLine($" code {p.ProCode} Name:{p.ProName}\n category :{p.ProCategory}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------------------------");

            var result9 = products.Where(p => p.ProCategory == "FMCG")
                                .OrderByDescending(p => p.ProMrp)
                                .FirstOrDefault();
            Console.WriteLine(result9);
            Console.WriteLine("----------------------------------");
            var result10 = products.Count();
            Console.WriteLine(result10);
            Console.WriteLine("----------------------------------");
            var result11 = products.Count(p => p.ProCategory == "FMCG");
            Console.WriteLine(result11);
            Console.WriteLine("----------------------------------");
            var result12 = products.Max(p => p.ProMrp);
            Console.WriteLine(result12);
            Console.WriteLine("----------------------------------");
            var result13 = products.Min(p => p.ProMrp);
            Console.WriteLine(result13);
            Console.WriteLine("----------------------------------");
            var result14 = products.All(p => p.ProMrp < 30);
            Console.WriteLine(result14);
            Console.WriteLine("----------------------------------");
            var result15 = products.Any(p => p.ProMrp < 30);
            Console.WriteLine(result15);
            Console.WriteLine("----------------------------------");

        }
    }
}
