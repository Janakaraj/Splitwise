using Splitwise.DomainModel.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.UserGroupRepository
{
    public interface IUserGroupRepository
    {
        Task<IEnumerable<UserAC>> GetGroupMembersByGroupId(int groupId);
        Task<IEnumerable<GroupAC>> GetUserGroupsByUserId(string userId);
        Task AddUserToGroup(string userId, int groupId);
        Task RemoveUserFromGroup(string userId, int groupId);
        bool GroupMemberExists(int id);
    }
}
