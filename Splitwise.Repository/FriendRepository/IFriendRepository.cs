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
        IEnumerable<UserAC> GetFriends(string userId);
        Task<UserAC> AddFriend(string userId, string userFriendEmail);
        Task<FriendAC> RemoveFriend(string userId, string userFriendId);
        bool FriendExistsByEmail(string userId, string userFriendEmail);
        bool FriendExistsById(string userId, string userFriendId);
    }
}
