using Splitwise.DomainModel.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.ExpenseRepository
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<ExpenseAC>> GetExpensesByGroupId(int groupId);
        Task<ExpenseAC> GetExpense(int expenseId);
        Task AddExpense(ExpenseAC expense);
        Task UpdateExpense(ExpenseAC expense);
        Task DeleteExpense(int expenseId);
        Task DeleteExpensesByGroupId(int groupId);
        bool ExpenseExists(int id);
    }
}
