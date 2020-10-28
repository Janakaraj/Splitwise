using Microsoft.AspNetCore.Identity;
using Splitwise.DomainModel.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.UserRepository
{
    public interface IUserRepository
    {
        IEnumerable<UserAC> GetUsers();
        Task<UserAC> GetUser(string userId);
        Task<UserAC> GetUserByEmailAsync(string userEmail);
        Task<IdentityResult> RegisterUser(RegisterUserAC user);
        Task UpdateUser(UserAC user);
        Task DeleteUser(UserAC user);
        bool UserExists(string userEmail);
    }
}
