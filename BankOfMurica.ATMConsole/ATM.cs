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

            var response = service.ValidateAccountAsync();

            if (!response.Result)
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

        private async static Task<int> MainMenu(int accountInput, int pinInput)
        {
            var accountService = new AccountService(accountInput, pinInput);
            var transactionService = new TransactionService(accountInput);
            ATMUtilities.NavigationMenu(); 

            var input = Console.ReadKey().Key;

            while (true)
            {
                switch (input)
                {
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        ATMUtilities.DisplayBalance(accountService.GetBalanceAsync().Result);
                        ATMUtilities.NewMenuScreen();
                        input = Console.ReadKey().Key;
                        break;

                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        await transactionService.WithdrawAsync(ATMUtilities.WithdrawalPrompt());
                        Console.Clear();
                        ATMUtilities.NewBalance(accountService.GetBalanceAsync().Result);
                        ATMUtilities.NewMenuScreen();
                        input = Console.ReadKey().Key;
                        break;

                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        await transactionService.DepositAsync(ATMUtilities.DepositPrompt());
                        Console.Clear();
                        ATMUtilities.NewBalance(accountService.GetBalanceAsync().Result);
                        ATMUtilities.NewMenuScreen();
                        input = Console.ReadKey().Key;
                        break;

                    case ConsoleKey.NumPad4:
                        Console.Clear();
                        
                        var returnValue = accountService.ChangePinAsync(ATMUtilities.PinChanger());
                        if (returnValue.Result)
                        {
                            Console.Clear();
                            ATMUtilities.PinChangeSuccess();
                        }
                        ATMUtilities.NewMenuScreen();
                        input = Console.ReadKey().Key;
                        break;

                    case ConsoleKey.NumPad5:
                        Console.Clear();
                        var target = ATMUtilities.TransferAccountPrompt();
                        Console.Clear();
                        var amount = ATMUtilities.TransferAmountPrompt();
                        Console.Clear();
                        await transactionService.TransferAsync(target, amount);
                        ATMUtilities.TransferSuccess(accountService.GetBalanceAsync().Result);
                        ATMUtilities.NewMenuScreen();
                        input = Console.ReadKey().Key;
                        break;

                    case ConsoleKey.NumPad6:
                        Console.Clear();
                        ATMUtilities.GetHistory();
                        Thread.Sleep(500);
                        var transactions = transactionService.GetAccountHistoryAsync();
                        ATMUtilities.HistoryRow(transactions.Result);
                        Thread.Sleep(3000);
                        ATMUtilities.NewMenuScreen();
                        input = Console.ReadKey().Key;
                        break;

                    case ConsoleKey.NumPad7:
                        Console.Clear();
                        ATMUtilities.SignOut();
                        Thread.Sleep(3000);
                        Console.Clear();
                        Login();
                        break;
                }

                return 0;
            }


        }
    }
}
