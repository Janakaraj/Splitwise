using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Splitwise.DomainModel;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.ExpenseRepository
{
    public class ExpenseRepository : IExpenseRepository
    {
        #region Private Variables
        private readonly IMapper _mapper;
        private readonly SplitwiseDbContext _context;
        #endregion
        #region Constructors
        public ExpenseRepository(SplitwiseDbContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }
        #endregion
        #region Public methods
        public async Task<ExpenseAC> AddExpense(ExpenseAC expense)
        {
            this._context.Expenses.Add(this._mapper.Map<Expense>(expense));
            await _context.SaveChangesAsync();
            var expenseName = expense.ExpenseName;
            var expenseGroupId = expense.ExpenseGroupId;
            var newExpense = this._context.Expenses.Where(e => (e.ExpenseName == expenseName)&&(e.ExpenseGroupId == expenseGroupId)).Select(e=>e).FirstOrDefault();
            return this._mapper.Map<ExpenseAC>(newExpense);
        }

        public async Task DeleteExpense(int expenseId)
        {
            var expense = await _context.Expenses.FindAsync(expenseId);
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
        }

        public Task DeleteExpensesByGroupId(int groupId)
        {
            throw new NotImplementedException();
        }

        public bool ExpenseExists(int id)
        {
            return _context.Expenses.Any(e => e.ExpenseId == id);
        }

        public async Task<ExpenseAC> GetExpense(int expenseId)
        {
            return _mapper.Map<ExpenseAC>(await this._context.Expenses.Where(e =>e.ExpenseId  == expenseId)
                .Include(g=>g.ExpenseGroup)
                .Include(u=>u.ExpenseAdder)
                .SingleOrDefaultAsync());
        }

        public async Task<IEnumerable<ExpenseAC>> GetExpensesByGroupId(int groupId)
        {
            var expenses = await this._context.Expenses.Where(e => e.ExpenseGroupId == groupId)
                .Include(g => g.ExpenseGroup)
                .Include(u => u.ExpenseAdder)
                .ToListAsync();
            return this._mapper.Map<IEnumerable<ExpenseAC>>(expenses);
        }

        public async Task UpdateExpense(ExpenseAC expense)
        {
            var expenseToUpdate = this._context.Expenses.Where(e => e.ExpenseId == expense.ExpenseId).FirstOrDefault();
            expenseToUpdate.ExpenseName = expense.ExpenseName;
            expenseToUpdate.ExpenseDescription = expense.ExpenseDescription;
            expenseToUpdate.ExpenseCurrency = expense.ExpenseCurrency;
            expenseToUpdate.ExpenseSplitBy = expense.ExpenseSplitBy;
            expenseToUpdate.ExpenseTotalAmount = expense.ExpenseTotalAmount;
            this._context.Expenses.Update(expenseToUpdate);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
