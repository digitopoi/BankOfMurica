using BankOfMurica.Models;
using System;
using System.Collections.Generic;
using static System.Console;
using System.Threading;

namespace BankOfMurica.ATMConsole
{
    public static class ATMUtilities
    {
        public static string EnterAccountNumber()
        {
            WriteLine("");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            WriteLine("                     ENTER YOUR ACCOUNT NUMBER                         ");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            Write("                            ");
            var input = Console.ReadLine();
            return input;
        }

        public static string EnterPin()
        {
            WriteLine("");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            WriteLine("                              ENTER                                    ");
            WriteLine("                             YOUR PIN                                  ");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            Write("                               ");
            var input = ReadLine();
            return input;
        }

        public static void NavigationMenu()
        {
            WriteLine("");
            WriteLine("=======================================================================");
            WriteLine("|                                                                     |");
            WriteLine("                               NAVIGATION MENU                         ");
            WriteLine("|                      (make selection on number pad)                 |");
            WriteLine("                                                                       ");
            WriteLine("|      [1] Check Balance                         [4] Change Pin       |");
            WriteLine("       [2] Make Withdrawal                       [5] Make Transfer     ");
            WriteLine("|      [3] Make Deposit                          [6] Account History  |");
            WriteLine("                               [7] Logout                              ");
            WriteLine("=======================================================================");
        }

        public static int PinChanger()
        {
            WriteLine("");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            WriteLine("                              ENTER                                    ");
            WriteLine("                             NEW PIN                                   ");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            Write("                               ");
            var newPin = Convert.ToInt32(ReadLine());
            return newPin;
        }
        public static void PinChangeSuccess()
        {
            WriteLine("");
            WriteLine("=======================================================================");
            WriteLine("|                                                                     |");
            WriteLine("                                                                       ");
            WriteLine("|                                                                     |");
            WriteLine("                         NEW PIN STORED!                               ");
            WriteLine("|                                                                     |");
            WriteLine("                                                                       ");
            WriteLine("|                                                                     |");
            WriteLine("                                                                       ");
            WriteLine("=======================================================================");
        }

        public static void DisplayBalance(decimal balance)
        {
            WriteLine("");
            WriteLine("=======================================================================");
            WriteLine("|                                                                     |");
            WriteLine("                                                                       ");
            WriteLine("|                                                                     |");
            WriteLine("                            ACCOUNT BALANCE:                           ");
            WriteLine("|                                                                     |");
            WriteLine($"                                {balance.ToString("C")}");
            WriteLine("|                                                                     |");
            WriteLine("                                                                       ");
            WriteLine("=======================================================================");
        }

        public static decimal WithdrawalPrompt()
        {
            WriteLine("");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            WriteLine("                How much would you like to withdraw?                   ");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            Write("                               ");
            var amount = Convert.ToDecimal(ReadLine());
            return amount;
        }

        public static void NewBalance(decimal balance)
        {
            WriteLine("");
            WriteLine("=======================================================================");
            WriteLine("|                                                                     |");
            WriteLine("                                                                       ");
            WriteLine("|                     WITHDRAWAL SUCCESSFUL!                          |");
            WriteLine("                            NEW BALANCE:                               ");
            WriteLine("|                                                                     |");
            WriteLine($"                                {balance.ToString("C")}");
            WriteLine("|                                                                     |");
            WriteLine("                                                                       ");
            WriteLine("=======================================================================");
        }

        public static decimal DepositPrompt()
        {
            WriteLine("");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            WriteLine("                How much would you like to deposit?                    ");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            Write("                               "); 
            var amount = Convert.ToDecimal(ReadLine());
            return amount;
        }

        public static int TransferAccountPrompt()
        {
            WriteLine("");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            WriteLine("                Enter the account you'd like to transfer to            ");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            Write("                               ");
            var amount = Convert.ToInt32(ReadLine());
            return amount;
        }

        public static decimal TransferAmountPrompt()
        {
            WriteLine("");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            WriteLine("                Enter the amount you'd like to transfer                ");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            WriteLine("                                                                       ");
            Write("                               ");
            var amount = Convert.ToDecimal(ReadLine());
            return amount;
        }

        public static void TransferSuccess(decimal balance)
        {
            WriteLine("");
            WriteLine("=======================================================================");
            WriteLine("|                                                                     |");
            WriteLine("                                                                       ");
            WriteLine("|                       TRANSFER SUCCESSFUL!                          |");
            WriteLine("                            NEW BALANCE:                               ");
            WriteLine("|                                                                     |");
            WriteLine($"                                {balance.ToString("C")}");
            WriteLine("|                                                                     |");
            WriteLine("                                                                       ");
            WriteLine("=======================================================================");
        }

        public static void GetHistory()
        {

            WriteLine("");
            WriteLine("=======================================================================");
            WriteLine("\tTYPE\t\t\tAMOUNT\t\t\tDATE                                             ");
            WriteLine("=======================================================================");
        }

        public static void HistoryRow(IEnumerable<Transaction> transactions)
        {
            foreach (var item in transactions)
            {
                WriteLine("\t{0}\t\t\t{1:c}\t\t\t{2:d}               ", item.TransactionType, item.BalanceDifference, item.TransactionDate);
                WriteLine("----------------------------------------------------------------------");
            }
        }

        public static void SignOut()
        {
            WriteLine("");
            WriteLine("=======================================================================");
            WriteLine("|                                                                     |");
            WriteLine("                                                                       ");
            WriteLine("|                                                                     |");
            WriteLine("                              GOODBYE!                                 ");
            WriteLine("|                                                                     |");
            WriteLine("                        You're now signed out.                         ");
            WriteLine("|                                                                     |");
            WriteLine("                                                                       ");
            WriteLine("=======================================================================");
        }

        public static void NewMenuScreen()
        {
            Thread.Sleep(5000);
            Clear();
            NavigationMenu();
        }
    }
}
