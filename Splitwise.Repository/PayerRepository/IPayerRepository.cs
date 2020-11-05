using Splitwise.DomainModel.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.PayerRepository
{
    public interface IPayerRepository
    {
        Task<IEnumerable<UserAC>> GetPayersByExpenseId(int expenseId);
        Task<IEnumerable<ExpenseAC>> GetExpensesByPayerId(string payerId);
        Task AddPayer(PayerAC payer);
        Task UpdatePayer(string payerId, int expenseId, PayerAC payer);
        Task DeletePayer(string payerId);
        bool PayerExists(string payerId);
    }
}
