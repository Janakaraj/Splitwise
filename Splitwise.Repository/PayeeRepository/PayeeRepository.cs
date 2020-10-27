using Splitwise.DomainModel.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.PayeeRepository
{
    class PayeeRepository : IPayeeRepository
    {
        public Task AddPayee(PayeeAC payee)
        {
            throw new NotImplementedException();
        }

        public Task DeletePayee(int payeeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExpenseAC>> GetExpensesByPayeeId(string payeeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserAC>> GetPayeesByExpenseId(int expenseId)
        {
            throw new NotImplementedException();
        }

        public bool PayeeExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePayee(PayeeAC payee)
        {
            throw new NotImplementedException();
        }
    }
}
