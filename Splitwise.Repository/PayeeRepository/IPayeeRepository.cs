using Splitwise.DomainModel.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.PayeeRepository
{
    interface IPayeeRepository
    {
        Task<IEnumerable<UserAC>> GetPayeesByExpenseId(int expenseId);
        Task<IEnumerable<ExpenseAC>> GetExpensesByPayeeId(string payeeId);
        Task AddPayee(PayeeAC payee);
        Task UpdatePayee(PayeeAC payee);
        Task DeletePayee(int payeeId);
        bool PayeeExists(int id);
    }
}
