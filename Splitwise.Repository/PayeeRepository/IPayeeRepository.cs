using Splitwise.DomainModel.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.PayeeRepository
{
    public interface IPayeeRepository
    {
        IEnumerable<UserAC> GetPayeesByExpenseId(int expenseId);
        IEnumerable<ExpenseAC> GetExpensesByPayeeId(string payeeId);
        Task AddPayee(PayeeAC payee);
        Task UpdatePayee(string payeeid, int expenseid, PayeeAC payee);
        Task DeletePayee(string payeeId);
        bool PayeeExists(string id);
    }
}
