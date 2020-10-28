using Splitwise.DomainModel.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.PayerRepository
{
    public class PayerRepository : IPayerRepository
    {
        public Task AddPayer(PayerAC payer)
        {
            throw new NotImplementedException();
        }

        public Task DeletePayer(int payerTableId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExpenseAC>> GetExpensesBypayerId(int payerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PayerAC>> GetPayersByExpenseId(int expenseId)
        {
            throw new NotImplementedException();
        }

        public bool PayerExists(int payerId)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePayer(PayerAC payer)
        {
            throw new NotImplementedException();
        }
    }
}
