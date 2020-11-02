using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Splitwise.DomainModel;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.SettlementRepository
{
    public class SettlementRepository : ISettlementRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly SplitwiseDbContext _context;
        public SettlementRepository(SplitwiseDbContext _context, UserManager<User> _userManager, IMapper _mapper)
        {
            this._context = _context;
            this._userManager = _userManager;
            this._mapper = _mapper;
        }
        public async Task AddSettlement(SettlementAC settlement)
        {
            this._context.Settlements.Add(this._mapper.Map<Settlement>(settlement));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSettlement(int id)
        {
            var settlement = await _context.Settlements.FindAsync(id);
            _context.Settlements.Remove(settlement);
            await _context.SaveChangesAsync();
        }

        public async Task<SettlementAC> GetSettlement(int settlementId)
        {
            return this._mapper.Map<SettlementAC>(await this._context.Settlements.Where(e=>e.SettlementId == settlementId).SingleOrDefaultAsync());
        }

        public IEnumerable<SettlementAC> GetSettlements()
        {
            return this._mapper.Map<IEnumerable<SettlementAC>>(this._context.Settlements);
        }

        public async Task<IEnumerable<SettlementAC>> GetSettlementsByGroupId(int groupId)
        {
            return this._mapper.Map<IEnumerable<SettlementAC>>(this._context.Settlements.Where(e => e.SettlementGroupId == groupId));
        }

        public async Task<IEnumerable<SettlementAC>> GetSettlementsByExpenseId(int expenseId)
        {
            return this._mapper.Map<IEnumerable<SettlementAC>>(this._context.Settlements.Where(e => e.SettlementExpenseId == expenseId));
        }

        public bool SettlementExists(int settlementId)
        {
            return this._context.Settlements.Any(s => s.SettlementId == settlementId);
        }

        public async Task UpdateSettlement(int id, SettlementAC settlement)
        {
            var settlementToUpdate = this._context.Settlements.Where(e => e.SettlementId == settlement.SettlementId).FirstOrDefault();
            settlementToUpdate.TransactionAmount = settlement.TransactionAmount;
            this._context.Settlements.Update(settlementToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
