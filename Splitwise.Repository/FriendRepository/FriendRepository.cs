using Splitwise.DomainModel.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.FriendRepository
{
    public class FriendRepository : IFriendRepository
    {
        public Task<UserAC> AddFriend(string userEmail)
        {
            throw new NotImplementedException();
        }

        public bool FriendExists(int friendUserId)
        {
            throw new NotImplementedException();
        }

        public Task<UserAC> GetFriend(string friendEmail)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserAC>> GetFriends(string userEmail)
        {
            throw new NotImplementedException();
        }

        public Task<UserAC> RemoveFriend(string userEmail)
        {
            throw new NotImplementedException();
        }
    }
}
