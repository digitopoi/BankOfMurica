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
            using (BankOfMuricaEntities context = new BankOfMuricaEntities())
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
            using (BankOfMuricaEntities context = new BankOfMuricaEntities())
            {
                var query = context
                              .Accounts
                              .Where(e => e.AccountNumber == _accountNum)
                              .Select(e => e.Balance)
                              .SingleOrDefault();
                return query;
            }
        }

        public bool ChangePin(byte newPin)
        {
            using (BankOfMuricaEntities context = new BankOfMuricaEntities())
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
