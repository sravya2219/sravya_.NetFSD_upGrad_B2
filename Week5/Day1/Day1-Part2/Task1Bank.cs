using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.HandsOn.WEEK5.Day2
{
    internal class Task1Bank
    {
        private string accountNumber;
        private double balance;
        public  string AccountNumber { get; set; }
        public  double Balance { get; set; }
        public  void Deposite(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid deposit amount!");
                return;
            }
            else
            {
                balance += amount;
                Console.WriteLine($"Deposited :{amount}");
                Console.WriteLine($"Current balance:{balance}");
            }
        }
        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid withdraw amount!");
                return;
            }
            else
            {
                balance -= amount;
                Console.WriteLine($"withdraw :{amount}");
                Console.WriteLine($"Current balance:{balance}");
            }
        }
        static void Main()
        {
            Task1Bank bank = new Task1Bank();
            bank.AccountNumber = "12345";
            bank.Deposite(5000);
            bank.Withdraw(2000);
        }
    }
}
