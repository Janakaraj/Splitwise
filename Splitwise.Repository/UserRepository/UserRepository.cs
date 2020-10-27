using Splitwise.DomainModel.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.UserRepository
{
    class UserRepository
    {
        public Task<IEnumerable<UserAC>> GetUsers() {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<UserAC>> GetAllFriends(string userId) {
            throw new NotImplementedException();
        }
        public Task<UserAC> GetUser(string userId) {
            throw new NotImplementedException();
        }
        public Task<UserAC> GetUserByEmail(string userEmail) {
            throw new NotImplementedException();
        }
        public Task CreateUser(UserAC user) {
            throw new NotImplementedException();
        }
        public void UpdateUser(UserAC user) {
            throw new NotImplementedException();
        }
        public Task DeleteUser(UserAC user) {
            throw new NotImplementedException();
        }
        public bool UserExists(string userId) {
            throw new NotImplementedException();
        }
    }
}
