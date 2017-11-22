using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfMurica.Services
{
    public interface IAccountService
    {
        Task<bool> ValidateAccountAsync();
        Task<decimal> GetBalanceAsync();
        Task<bool> ChangePinAsync(int newPin);
    }
}
