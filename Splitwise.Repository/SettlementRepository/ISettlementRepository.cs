using Splitwise.DomainModel.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.SettlementRepository
{
    public interface ISettlementRepository
    {
        Task <IEnumerable<SettlementAC>> GetSettlementsByGroupId(int groupId);
        Task<IEnumerable<SettlementAC>> GetSettlementsByExpenseId(int expenseId);
        Task<SettlementAC> GetSettlement(int settlementId);
        Task AddSettlement(SettlementAC settlement);
        Task UpdateSettlement(int id, SettlementAC settlement);
        Task DeleteSettlement(int id);
        bool SettlementExists(int settlementId);
        IEnumerable<SettlementAC> GetSettlements();
    }
}
