using Splitwise.DomainModel.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.GroupRepository
{
    public class GroupRepository : IGroupRepository
    {
        public Task CreateGroup(GroupAC group)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGroup(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GroupAC> GetGroup(int groupId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GroupAC>> GetGroups(string userEmail)
        {
            throw new NotImplementedException();
        }

        public bool GroupExists(int groupId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGroup(GroupAC group)
        {
            throw new NotImplementedException();
        }
    }
}
