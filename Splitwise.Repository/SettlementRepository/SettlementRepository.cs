using Splitwise.DomainModel.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.SettlementRepository
{
    class SettlementRepository : ISettlementRepository
    {
        public Task AddSettlement(SettlementAC settlement)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSettlement(SettlementAC settlement)
        {
            throw new NotImplementedException();
        }

        public Task<SettlementAC> GetSettlement(int settlementId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SettlementAC>> GetSettlementsByGroupId(int groupId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SettlementAC>> GetSettlementsByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public bool SettlementExists(int settlementId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSettlement(SettlementAC settlement)
        {
            throw new NotImplementedException();
        }
    }
}
