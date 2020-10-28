using Splitwise.DomainModel.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.ExpenseRepository
{
    public class ExpenseRepository : IExpenseRepository
    {
        public Task AddExpense(ExpenseAC expense)
        {
            throw new NotImplementedException();
        }

        public Task DeleteExpense(int expenseId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteExpensesByGroupId(int groupId)
        {
            throw new NotImplementedException();
        }

        public bool ExpenseExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ExpenseAC> GetExpense(int expenseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExpenseAC>> GetExpensesByGroupId(int groupId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateExpense(ExpenseAC expense)
        {
            throw new NotImplementedException();
        }
    }
}
