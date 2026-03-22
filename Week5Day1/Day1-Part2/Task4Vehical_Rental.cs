using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.HandsOn.WEEK5.Day2
{
    using System;

    // Base class
    class Vehicle
    {
        protected string brand;
        protected double rentalRatePerDay;

        public Vehicle(string brand, double rate)
        {
            this.brand = brand;
            this.rentalRatePerDay = rate;
        }

        // Virtual method
        public virtual double CalculateRental(int days)
        {
            if (days <= 0)
            {
                Console.WriteLine("Invalid number of days");
                return 0;
            }
            return rentalRatePerDay * days;
        }
    }

    // Derived class: Car
    class Car : Vehicle
    {
        public Car(string brand, double rate) : base(brand, rate) { }

        public override double CalculateRental(int days)
        {
            double baseAmount = base.CalculateRental(days);
            return baseAmount + 500; // Insurance charge
        }
    }

    // Derived class: Bike
    class Bike : Vehicle
    {
        public Bike(string brand, double rate) : base(brand, rate) { }

        public override double CalculateRental(int days)
        {
            double baseAmount = base.CalculateRental(days);
            return baseAmount - (baseAmount * 0.05); // 5% discount
        }
    }

    // Main class
    class Program
    {
        static void Main()
        {
            Vehicle v;

            // Car Example
            v = new Car("Toyota", 2000);
            double total = v.CalculateRental(3);
            Console.WriteLine("Total Rental = " + total);

            // Bike Example
            v = new Bike("Honda", 1000);
            double totalBike = v.CalculateRental(2);
            Console.WriteLine("Bike Rental = " + totalBike);
        }
    }
    public class Task4Vehical_Rental
    {
        
    }
}
