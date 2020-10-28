using Splitwise.DomainModel.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.UserGroupRepository
{
    public class UserGroupRepository : IUserGroupRepository
    {
        public Task AddUserToGroup(string userId, int groupId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserAC>> GetGroupMembersByGroupId(int groupId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GroupAC>> GetUserGroupsByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public bool GroupMemberExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveUserFromGroup(string userId, int groupId)
        {
            throw new NotImplementedException();
        }
    }
}
