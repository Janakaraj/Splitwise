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

namespace Splitwise.Repository.PayerRepository
{
    public class PayerRepository : IPayerRepository
    {
        private readonly IMapper _mapper;
        private readonly SplitwiseDbContext _context;

        public PayerRepository(SplitwiseDbContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }
        public async Task AddPayer(PayerAC payer)
        {
            this._context.Payers.Add(this._mapper.Map<Payer>(payer));
            await _context.SaveChangesAsync();
        }

        public async Task DeletePayer(string payerId)
        {
            var payer = await _context.Payers.FindAsync(payerId);
            _context.Payers.Remove(payer);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<ExpenseAC> GetExpensesByPayerId(string payerId)
        {
            return this._mapper.Map<IEnumerable<ExpenseAC>>(this._context.Payers
                .Where(p => p.PayerId == payerId)
                .Include(p => p.Expense)
                .Select(p => p.Expense));
        }

        public IEnumerable<UserAC> GetPayersByExpenseId(int expenseId)
        {
            return this._mapper.Map<IEnumerable<UserAC>>(this._context.Payers
                .Where(p => p.ExpenseId == expenseId)
                .Include(p => p.PayerUser)
                .Select(p => p.PayerUser));
        }

        public bool PayerExists(string payerId)
        {
            return _context.Payers.Any(e => e.PayerId == payerId);
        }

        public async Task UpdatePayer(string payerId, int expenseId, PayerAC payer)
        {
            var payerToUpdate = this._context.Payers.Where(e => (e.PayerId == payerId) && (e.ExpenseId == expenseId)).FirstOrDefault();
            payerToUpdate.AmountPaid = payer.AmountPaid;
            this._context.Payers.Update(payerToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
