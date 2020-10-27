using Splitwise.DomainModel.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.PayerRepository
{
    interface IPayerRepository
    {
        Task<IEnumerable<PayerAC>> GetPayersByExpenseId(int expenseId);
        Task<IEnumerable<ExpenseAC>> GetExpensesBypayerId(int payerId);
        Task AddPayer(PayerAC payer);
        Task UpdatePayer(PayerAC payer);
        Task DeletePayer(int payerTableId);
        bool PayerExists(int payerId);
    }
}
