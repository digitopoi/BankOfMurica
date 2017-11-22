using BankOfMurica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfMurica.Services
{
    public class AccountService : IAccountService
    {
        private readonly int _accountNum;
        private readonly int _accountPin;

        public AccountService (int accountNum, int accountPin)
        {
            _accountNum = accountNum;
            _accountPin = accountPin;
        }

        public async Task<bool> ValidateAccountAsync()
        {
            using (BankEntities context = new BankEntities())
            {
                var query = await context
                                         .Accounts
                                         .Where(e => e.AccountNumber == _accountNum && e.Pin == _accountPin)
                                         .SingleOrDefaultAsync();

                if (query != null)
                    return true;
                else
                    return false;
            }
        }

        public async Task<decimal> GetBalanceAsync()
        {
            using (BankEntities context = new BankEntities())
            {
                var query = await context
                                        .Accounts
                                        .Where(e => e.AccountNumber == _accountNum)
                                        .Select(e => e.Balance)
                                        .SingleOrDefaultAsync();
                return query;
            }
        }

        public async Task<bool> ChangePinAsync(int newPin)
        {
            if (newPin < 1000 || newPin > 9999)
            {
                return false;
            }
            using (BankEntities context = new BankEntities())
            {
                var query = await context
                                        .Accounts
                                        .Where(e => e.AccountNumber == _accountNum)
                                        .SingleOrDefaultAsync();

                query.Pin = newPin;

                return await context.SaveChangesAsync() == 1;
                
            }
        }

    }
}
