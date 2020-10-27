using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Splitwise.DomainModel.ApplicationClasses;

namespace Splitwise.Repository.GroupRepository
{
    interface IGroupRepository
    {
        Task<IEnumerable<GroupAC>> GetGroups();
        Task<GroupAC> GetGroup();
        Task CreateGroup(GroupAC group);
        Task UpdateGroup(GroupAC group);
        Task DeleteGroup(int id);
    }
}
