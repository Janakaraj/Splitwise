using Splitwise.DomainModel.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.SettlementRepository
{
    public interface ISettlementRepository
    {
        Task <IEnumerable<SettlementAC>> GetSettlementsByUserId(string userId);
        Task <IEnumerable<SettlementAC>> GetSettlementsByGroupId(int groupId);
        Task<SettlementAC> GetSettlement(int settlementId);
        Task AddSettlement(SettlementAC settlement);
        Task UpdateSettlement(SettlementAC settlement);
        Task DeleteSettlement(SettlementAC settlement);
        bool SettlementExists(int settlementId);
    }
}
