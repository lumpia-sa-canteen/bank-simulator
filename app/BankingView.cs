public static class BankingView
    {
        public static void run()
        {
            double balance = 1000.00;
            bool isRunning = true;
            
            lastTransactionAmount = 0;
            
            Console.WriteLine("JOHN BENEDICT BERE");
            Console.WriteLine("===SIMPLE ATM SYSTEM===");
            Console.WriteLine($"INITIAL BALANCE (Php): {balance}");
            
            while(isRunning)
            {
                Console.WriteLine("MENU");
                Console.WriteLine();
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Print Mini Statement");
                Console.WriteLine("5. Exit");
                Console.WriteLine();
                Console.WriteLine("Select an Option: ");
                string input = Console.ReadLine();
                
                int option;
                bool validOption = int.TryParse(input, out option);
                
                if(!validOption || option < 1 || option > 5)
                {
                    Console.WriteLine("INVALID OPTION!!! PLEASE TRY AGAIN!!");
                    continue;
                }
                switch(option)
                {
                    case 1:
                        Console.WriteLine($"Current Balance (Php): {BankingServices.GetBalance(balance)}");
                        break;
                        
                    case 2:
                        Console.WriteLine("Enter Amount To Deposit (Php): ");
                        if(double.TryParse(Console.ReadLine(), out double depositAmount))
                        {
                            if(BankingServices.Deposit(ref balance, depositAmount))
                            {
                                Console.WriteLine($"Deposit Successful. Updated Balance (Php): {balance}");
                            }
                            else
                            {
                                Console.WriteLine("INVALID DEPOSIT AMOUNT!!! PLEASE TRY AGAIN!!!!!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("INVALID DEPOSIT AMOUNT!!!! PLEASE ENTER A VALID VALUE!!!!!");
                        }
                        break;
                    
                    case 3:
                        Console.WriteLine("Enter amount to withdraw (Php): ");
                        if(double.TryParse(Console.ReadLine(), out double withdrawAmount))
                        {
                            BankingServices.Withdraw(ref balance, withdrawAmount, out bool isSuccessful);
                            if(isSuccessful)
                            {
                                Console.WriteLine($"Withdrawal Successful. Updated Balance (Php): {balance}");
                            }
                            else
                            {
                                if(withdrawAmount <= 0)
                                {
                                    Console.WriteLine("INVALID WITHDRAWAL AMOUNT!! PLEASE TRY AGAIN");
                                }
                                else
                                {
                                    Console.WriteLine("WITHDRAWAL FAILED!! INSUFFICIENT BALANCE.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("INVALID WITHDRAWAL AMOUNT!!! PLEASE ENTER A VALID VALUE!!");
                        }
                        break;
                        
                        case 4:
                            BankingServices.Print(balance);
                            break;
                        
                        case 5:
                            Console.WriteLine("Thank you have a good day!");
                            isRunning = false;
                            break;
                }
            }
        }
    }
}
