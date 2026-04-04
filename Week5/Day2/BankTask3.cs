using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.HandsOn.WEEK5
{
    internal class BankTask3
    {
        public class InsufficientBalanceException : Exception
        {
            public InsufficientBalanceException(string message) : base(message)
            {
            }
        }

        // ✅ BankAccount Class
        public class BankAccount
        {
            private double balance;

            public BankAccount(double initialBalance)
            {
                balance = initialBalance;
            }

            public void Withdraw(double amount)
            {
                if (amount > balance)
                {
                    // Throw custom exception
                    throw new InsufficientBalanceException("Insufficient balance for this withdrawal.");
                }

                balance -= amount;
                Console.WriteLine($"Withdrawal successful! Remaining Balance: {balance}");
            }
        }

        // ✅ Main Program
        class Program
        {
            static void Main()
            {
                Console.Write("Enter initial balance: ");
                double initialBalance = Convert.ToDouble(Console.ReadLine());

                BankAccount account = new BankAccount(initialBalance);

                Console.Write("Enter withdrawal amount: ");
                double amount = Convert.ToDouble(Console.ReadLine());

                try
                {
                    account.Withdraw(amount);
                }
                catch (InsufficientBalanceException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected error: " + ex.Message);
                }
                finally
                {
                    Console.WriteLine("Transaction process completed.");
                }

                Console.WriteLine("Program continues...");
            }
        }
    }
}
