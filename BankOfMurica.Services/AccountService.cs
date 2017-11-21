using BankOfMurica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfMurica.Services
{
    public class AccountService
    {
        private readonly int _accountNum;
        private readonly int _accountPin;

        public AccountService (int accountNum, int accountPin)
        {
            _accountNum = accountNum;
            _accountPin = accountPin;
        }

        public bool CheckAccount()
        {
            using (BankOfMuricaEntities db = new BankOfMuricaEntities())
            {
                var query = db
                              .Accounts
                              .Where(e => e.AccountNumber == _accountNum && e.Pin == _accountPin)
                              .SingleOrDefault();

                if (query != null)
                    return true;
                else
                    return false;
            }
        }

        public decimal CheckBalance()
        {

        }

        public bool ChangePin()
        {

        }

    }
}
