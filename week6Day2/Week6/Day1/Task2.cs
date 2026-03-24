using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.HandsOn.Week6.Day1
{
    internal interface IDiscountStrategy
    {
        double CalculateDiscount(double amount);
    }
    public class RegularCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.1;
        }
    }
    public class PremiumCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.3;
        }
    }
    public class VipCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.5;
        }
    }
    class Program1
    {
        static void Main()
        {
            IDiscountStrategy d1 = new RegularCustomerDiscount();
            Console.WriteLine(d1.CalculateDiscount(100));
            IDiscountStrategy d2 = new PremiumCustomerDiscount();
            Console.WriteLine(d2.CalculateDiscount(100));
            IDiscountStrategy d3 = new VipCustomerDiscount();
            Console.WriteLine(d3.CalculateDiscount(100));
        }
    }
}
