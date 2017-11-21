using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfMurica.ATMConsole
{
    public static class ATMUtilities
    {
        public static void NavigationMenu()
        {
            Console.WriteLine("\n\n\n\n\n\n");
            Console.WriteLine("\t\t=======================================================================");
            Console.WriteLine("\t\t|                                                                     |");
            Console.WriteLine("\t\t|                              NAVIGATION MENU                        |");
            Console.WriteLine("\t\t|                      (make selection on number pad)                 |");
            Console.WriteLine("\t\t|                                                                     |");
            Console.WriteLine("\t\t|      [1] Check Balance                         [4] Change Pin       |");
            Console.WriteLine("\t\t|      [2] Make Withdrawal                       [5] Make Transfer    |");
            Console.WriteLine("\t\t|      [3] Make Deposit                          [6] Signout          |");
            Console.WriteLine("\t\t|                                                                     |");
            Console.WriteLine("\t\t=======================================================================");
        }

        public static int PinChanger()
        {
            Console.WriteLine("\n\n\n\n\n\n");
            Console.WriteLine("\t\t=======================================================================");
            Console.WriteLine("\t\t|                                                                     |");
            Console.WriteLine("\t\t|                                                                     |");
            Console.WriteLine("\t\t|                                                                     |");
            Console.WriteLine("\t\t|                           ENTER NEW PIN:                            |");
            Console.WriteLine("\t\t|                                                                     |");
            Console.WriteLine("\t\t|                                                                     |");
            Console.WriteLine("\t\t|                                                                     |");
            Console.WriteLine("\t\t|                                                                     |");
            Console.WriteLine("\t\t=======================================================================");
            int[] keyArray = new int[3];
            for (var i = 0; i < 2; i++)
            {
                keyArray[i] = Convert.ToInt32(Console.Read());
            }
            var intString = String.Join("", keyArray);
            var newPin = Convert.ToInt32(intString);

            return newPin;
        }

        public static void DisplayBalance(decimal balance)
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("|                           ACCOUNT BALANCE:                          |");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine($"|                               {balance.ToString("C")}");                
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("|                                                                     |");
            Console.WriteLine("=======================================================================");
        }
    }
}
