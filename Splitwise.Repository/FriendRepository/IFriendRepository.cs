using Splitwise.DomainModel.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.FriendRepository
{
    public interface IFriendRepository
    {
        Task<UserAC> GetFriend(string friendEmail);
        Task<IEnumerable<UserAC>> GetFriends(string userEmail);
        Task<UserAC> AddFriend(string userEmail);
        Task<UserAC> RemoveFriend(string userEmail);
        bool FriendExists(int friendUserId);
    }
}
