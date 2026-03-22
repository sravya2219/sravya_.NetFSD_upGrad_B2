using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.Day5
{
    internal class BankAccount
    {
        private double balance;
        public void Deposite(double amount)
        {
            balance = balance + amount;
        }
        public void Withdraw(double amount)
        {
            balance = balance - amount;
        }
        public double GetBalance()
        {
            return balance;
        }
        static void Main()
        {
            BankAccount account = new BankAccount();
            account.Deposite(1000);
            account.Withdraw(300);
            Console.WriteLine("current balance" + account.GetBalance);

        }

    }
}
