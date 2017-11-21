using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankOfMurica.ATMConsole
{
    public static class ATMUtilities
    {
        public static string EnterAccountNumber()
        {
            Console.WriteLine("");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("                              ENTER                                    ");
            Console.WriteLine("                        YOUR ACCOUNT NUMBER                            ");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("                                                                       ");
            Console.Write("                            ");
            var input = Console.ReadLine();
            return input;
        }

        public static string EnterPin()
        {
            Console.WriteLine("");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("                              ENTER                                    ");
            Console.WriteLine("                             YOUR PIN                                  ");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("                                                                       ");
            Console.Write("                               ");
            var input = Console.ReadLine();
            return input;
        }

        public static void NavigationMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("=======================================================================");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("                               NAVIGATION MENU                         ");
            Console.WriteLine("|                      (make selection on number pad)                 |");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("|      [1] Check Balance                         [4] Change Pin       |");
            Console.WriteLine("       [2] Make Withdrawal                       [5] Make Transfer     ");
            Console.WriteLine("|      [3] Make Deposit                          [6] Signout          |");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("=======================================================================");
        }

        public static int PinChanger()
        {
            Console.WriteLine("");
            Console.WriteLine("=======================================================================");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("                            ENTER NEW PIN:                             ");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("=======================================================================");
            Console.Write("                                 ");
            var newPin = Convert.ToInt32(Console.ReadLine());
            return newPin;
        }
        public static void PinChangeSuccess()
        {
            Console.WriteLine("");
            Console.WriteLine("=======================================================================");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("                         NEW PIN STORED!                               ");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("=======================================================================");
        }

        public static void DisplayBalance(decimal balance)
        {
            Console.WriteLine("");
            Console.WriteLine("=======================================================================");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("                            ACCOUNT BALANCE:                           ");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine($"                                {balance.ToString("C")}");                
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("=======================================================================");
        }

        public static decimal WithdrawalPrompt()
        {
            Console.WriteLine("");
            Console.WriteLine("=======================================================================");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("                   How much would you like to withdraw?                ");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine($"                                                                      "); 
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("=======================================================================");
            Console.Write("                                 ");
            var amount = Convert.ToDecimal(Console.ReadLine());
            return amount;
        }

        public static void NewBalance(decimal balance)
        {
            Console.WriteLine("");
            Console.WriteLine("=======================================================================");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("|                     WITHDRAWAL SUCCESSFUL!                          |");
            Console.WriteLine("                            NEW BALANCE:                               ");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine($"                                {balance.ToString("C")}");                
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("=======================================================================");
        }

        public static decimal DepositPrompt()
        {
            Console.WriteLine("");
            Console.WriteLine("=======================================================================");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("                   How much would you like to deposit?                 ");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine($"                                                                      ");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("                                                                       ");
            Console.WriteLine("=======================================================================");
            Console.Write("                                 ");
            var amount = Convert.ToDecimal(Console.ReadLine());
            return amount;
        }

            public static void NewMenuScreen()
        {
            Thread.Sleep(5000);
            Console.Clear();
            NavigationMenu();
        }
    }
}
