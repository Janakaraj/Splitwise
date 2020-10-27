using Splitwise.DomainModel.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.UserRepository
{
    interface IUserRepository
    {
        Task<IEnumerable<UserAC>> GetUsers();
        Task<IEnumerable<UserAC>> GetAllFriends(string userId);
        Task<UserAC> GetUser(string userId);
        Task<UserAC> GetUserByEmail(string userEmail);
        Task CreateUser(UserAC user);
        void UpdateUser(UserAC user);
        Task DeleteUser(UserAC user);
        bool UserExists(string userId);
    }
}
