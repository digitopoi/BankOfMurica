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
            using (BankEntities context = new BankEntities())
            {
                var query = context
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
            using (BankEntities context = new BankEntities())
            {
                var query = context
                              .Accounts
                              .Where(e => e.AccountNumber == _accountNum)
                              .Select(e => e.Balance)
                              .SingleOrDefault();
                return query;
            }
        }

        public bool ChangePin(int newPin)
        {
            using (BankEntities context = new BankEntities())
            {
                var query = context
                               .Accounts
                               .Where(e => e.AccountNumber == _accountNum)
                               .SingleOrDefault();

                query.Pin = newPin;

                return context.SaveChanges() == 1;
            }
        }

    }
}
