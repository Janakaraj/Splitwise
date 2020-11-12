using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Splitwise.DomainModel;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using Splitwise.Repository.PayeeRepository;
using Splitwise.Repository.PayerRepository;
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
        private readonly IPayerRepository _payerRepository;
        private readonly IPayeeRepository _payeeRepository;
        public SettlementRepository(SplitwiseDbContext context, UserManager<User> userManager, IMapper mapper, IPayerRepository payerRepository, IPayeeRepository payeeRepository)
        {
            this._context = context;
            this._userManager = userManager;
            this._mapper = mapper;
            this._payerRepository = payerRepository;
            this._payeeRepository = payeeRepository;
        }
        public async Task AddSettlement(SettlementAC settlement)
        {
            this._context.Settlements.Add(this._mapper.Map<Settlement>(settlement));
            var payerToUpdate = this._context.Payers.Where(e => (e.ExpenseId == settlement.SettlementExpenseId) && (e.PayerId == settlement.UserRecievingId))
                .FirstOrDefault();
            payerToUpdate.PayerShare = payerToUpdate.PayerShare + settlement.TransactionAmount;
            var payerToUpdateAC = _mapper.Map<PayerAC>(payerToUpdate);
            await this._payerRepository.UpdatePayer(settlement.UserRecievingId, settlement.SettlementExpenseId, payerToUpdateAC);
            var payeeToUpdate = this._context.Payees.Where(e => (e.ExpenseId == settlement.SettlementExpenseId) && (e.PayeeId == settlement.UserPayingId))
                .FirstOrDefault();
            payeeToUpdate.PayeeShare = payeeToUpdate.PayeeShare - settlement.TransactionAmount;
            var payeeToUpdateAC = _mapper.Map<PayeeAC>(payeeToUpdate);
            await this._payeeRepository.UpdatePayee(settlement.UserPayingId, settlement.SettlementExpenseId, payeeToUpdateAC);
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

        public async Task<IEnumerable<SettlementAC>> GetSettlements()
        {
            return this._mapper.Map<IEnumerable<SettlementAC>>(await this._context.Settlements.Select(e=>e).ToListAsync());
        }

        public async Task<IEnumerable<SettlementAC>> GetSettlementsByGroupId(int groupId)
        {
            return this._mapper.Map<IEnumerable<SettlementAC>>(await this._context.Settlements
                .Where(e => e.SettlementGroupId == groupId)
                .Include(e=>e.SettlementExpense)
                .Include(e=>e.Group)
                .Include(e=>e.UserPaying)
                .Include(e=>e.UserRecieving)
                .ToListAsync());
        }

        public async Task<IEnumerable<SettlementAC>> GetSettlementsByExpenseId(int expenseId)
        {
            return this._mapper.Map<IEnumerable<SettlementAC>>(await this._context.Settlements.Where(e => e.SettlementExpenseId == expenseId).ToListAsync());
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
