using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.HandsOn.WEEK5.Day2
{
    using System;

    // Base class
    class Product
    {
        private double price;   // encapsulation
        public string Name;

        // Property with validation
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    price = 0;
                else
                    price = value;
            }
        }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        // Virtual method
        public virtual double CalculateDiscount()
        {
            return Price;
        }
    }

    // Electronics class
    class Electronics : Product
    {
        public Electronics(string name, double price) : base(name, price) { }

        public override double CalculateDiscount()
        {
            return Price - (Price * 5 / 100); // 5% discount
        }
    }

    // Clothing class
    class Clothing : Product
    {
        public Clothing(string name, double price) : base(name, price) { }

        public override double CalculateDiscount()
        {
            return Price - (Price * 15 / 100); // 15% discount
        }
    }

    // Main
    class  Task3Products
    {
        static void Main()
        {
            Product p;

            // Electronics
            p = new Electronics("Laptop", 20000);
            Console.WriteLine("Final Price after 5% discount = " + p.CalculateDiscount());

            // Clothing
            p = new Clothing("Shirt", 2000);
            Console.WriteLine("Final Price after 15% discount = " + p.CalculateDiscount());
        }
    }
}
