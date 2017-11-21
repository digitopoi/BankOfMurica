using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfMurica.Services;
using System.Threading;

namespace BankOfMurica.ATMConsole
{
    public class ATM
    {
        public static void Login()
        {
            var accountInput = Int32.Parse(ATMUtilities.EnterAccountNumber());

            Console.Clear();

            var pinInput = Int32.Parse(ATMUtilities.EnterPin());

            var service = new AccountService(accountInput, pinInput);

            var response = service.CheckAccount();

            if (!response)
            {
                Console.WriteLine("I'm sorry, that account and pin combination was not found.");
                Console.WriteLine("Please login again.");
                Thread.Sleep(1500);
                Console.Clear();
                Login();
            }
            else
            {
                Console.Clear();
                MainMenu(accountInput, pinInput);
            }
            
        }

        private static void MainMenu(int accountInput, int pinInput)
        {
            var service = new AccountService(accountInput, pinInput);
            ATMUtilities.NavigationMenu(); 

            var input = Console.ReadKey().Key;

            while (input != ConsoleKey.NumPad6)
            {
                switch (input)
                {
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        var balance = service.CheckBalance();
                        ATMUtilities.DisplayBalance(balance);
                        Thread.Sleep(5000);
                        Console.Clear();
                        ATMUtilities.NavigationMenu();
                        input = Console.ReadKey().Key;
                        break;

                    //case ConsoleKey.NumPad2:
                    //    Console.Clear();
                    //    Withdrawal();
                    //    break;

                    //case ConsoleKey.NumPad3:
                    //    Console.Clear();
                    //    Deposit();
                    //    break;

                    case ConsoleKey.NumPad4:
                        Console.Clear();
                        
                        var returnValue = service.ChangePin(ATMUtilities.PinChanger());
                        if (returnValue)
                        {
                            Console.Clear();
                            ATMUtilities.PinChangeSuccess();
                        }
                        Thread.Sleep(1500);
                        Console.Clear();
                        ATMUtilities.NavigationMenu();
                        input = Console.ReadKey().Key;
                        break;

                    //case ConsoleKey.NumPad5:
                    //    Console.Clear();
                    //    Transfer();
                    //    break;

                    //case ConsoleKey.NumPad6:
                    //    Console.Clear();
                    //    SignOut();
                    //    break;
                }
            }


        }
    }
}
