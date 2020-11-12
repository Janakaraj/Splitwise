using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Splitwise.DomainModel;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.PayeeRepository
{
    public class PayeeRepository : IPayeeRepository
    {
        #region Private Variables
        private readonly IMapper _mapper;
        private readonly SplitwiseDbContext _context;
        #endregion

        #region Constructors
        public PayeeRepository(SplitwiseDbContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }
        #endregion
        #region Public methods
        public async Task AddPayee(PayeeAC payee)
        {
            this._context.Payees.Add(this._mapper.Map<Payee>(payee));
            await _context.SaveChangesAsync();
        }

        public async Task DeletePayee(string payeeId)
        {
            var payee = await _context.Payees.FindAsync(payeeId);
            _context.Payees.Remove(payee);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PayeeAC>> GetExpensesByPayeeId(string payeeId)
        {
            var expenses = await this._context.Payees
                .Where(p => p.PayeeId == payeeId)
                .Include(p => p.Expense)
                .Include(p=>p.PayeeUser)
                .Select(p => p)
                .ToListAsync();
            return this._mapper.Map<IEnumerable<PayeeAC>>(expenses);
        }

        public async Task<IEnumerable<PayeeAC>> GetPayeesByExpenseId(int expenseId)
        {
            var payees = await this._context.Payees
                .Where(p => p.ExpenseId == expenseId)
                .Include(p => p.PayeeUser)
                .Select(p => p)
                .ToListAsync();
            return this._mapper.Map<IEnumerable<PayeeAC>>(payees);
        }

        public bool PayeeExists(string id)
        {
            return _context.Payees.Any(e => e.PayeeId == id);
        }
        public async Task UpdatePayee(string payeeid,int expenseid, PayeeAC payee)
        {
            var payeeToUpdate = this._context.Payees.Where(e => (e.PayeeId==payeeid)&&(e.ExpenseId == expenseid)).FirstOrDefault();
            payeeToUpdate.PayeeShare = payee.PayeeShare;
            this._context.Payees.Update(payeeToUpdate);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
