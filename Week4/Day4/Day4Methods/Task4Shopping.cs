using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.Day4Methods
{
    internal class Task4Shopping
    {
       
        public static void CalculateFinalAmount(double price, int quantity, double discount = 0, double shipping = 50)
        {
            double subtotal = price * quantity;
            double discountAmount = subtotal * discount / 100;
            double amountAfterDiscount = subtotal - discountAmount;
            double finalAmount = amountAfterDiscount + shipping;

            Console.WriteLine("Subtotal: " + subtotal);
            Console.WriteLine("Discount Applied: " + discountAmount);
            Console.WriteLine("Shipping Charge: " + shipping);
            Console.WriteLine("Final Payable Amount: " + finalAmount);
        }

        static void Main()
        {
            // Call with default discount and shipping
            Console.WriteLine("Order 1");
            CalculateFinalAmount(500, 2);

            Console.WriteLine();

            // Call with discount only
            Console.WriteLine("Order 2");
            CalculateFinalAmount(500, 2, 10);

            Console.WriteLine();

            // Call with discount and shipping
            Console.WriteLine("Order 3");
            CalculateFinalAmount(500, 2, 10, 100);
        }
    }

}
