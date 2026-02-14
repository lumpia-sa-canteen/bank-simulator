using System;

namespace ATMApp.Services
{
    public static class BankingServices
    {
        // Option 1: Pass-by-value
        
        private static double lastTransactionAmount = 0;
        
        public static double GetBalance(double balance)
        {
            return balance;
        }

        // Option 2: ref (Deposit)
        public static bool Deposit(ref double balance, double amount)
        {
            if(amount > 0)
            {
                balance += amount;
                lastTransacationAmount = amount;
                return true;
            }
            return false;
        }

        // Option 3: ref + out (Withdraw)
        public static void Withdraw(
            ref double balance,
            double amount,
            out bool isSuccessful)
        {
            isSuccessful = false; //placeholder value, replace with actual implementation
            
            if(amount > 0)
            {
                if(amount >= balance)
                {
                    balance -= amount;
                    lastTransactionAmount = -amount;
                    isSuccessful = true;
                }
            }
        }
        public static void Print(double balance)
        {
            Console.WriteLine("---BSCS BANKO CENTRAL NG YOSI---");
            Console.WriteLine($"Current Balance (Php): {balance}");
            Console.WriteLine("Last Transaction Amount (Php): {lastTransactionAmount}");
        }
    }
