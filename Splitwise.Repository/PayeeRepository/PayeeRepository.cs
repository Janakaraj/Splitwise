﻿using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly SplitwiseDbContext _context;


        public PayeeRepository(SplitwiseDbContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }
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

        public IEnumerable<ExpenseAC> GetExpensesByPayeeId(string payeeId)
        {
            return this._mapper.Map<IEnumerable<ExpenseAC>>(this._context.Payees
                .Where(p => p.PayeeId == payeeId)
                .Include(p => p.Expense)
                .Select(p => p.Expense));
        }

        public IEnumerable<UserAC> GetPayeesByExpenseId(int expenseId)
        {
            return this._mapper.Map<IEnumerable<UserAC>>(this._context.Payees
                .Where(p=>p.ExpenseId==expenseId)
                .Include(p=>p.PayeeUser)
                .Select(p=>p.PayeeUser));
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
    }
}
