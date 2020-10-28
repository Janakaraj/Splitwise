using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Splitwise.DomainModel;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.UserRepository
{
    public class UserRepository:IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly SplitwiseDbContext _context;


        public UserRepository(SplitwiseDbContext _context, UserManager<User> _userManager, IConfiguration _configuration, IMapper _mapper)
        {
            this._context = _context;
            this._userManager = _userManager;
            this._configuration = _configuration;
            this._mapper = _mapper;
        }
        public IEnumerable<UserAC> GetUsers() {
            return this._mapper.Map<IEnumerable<UserAC>>(this._userManager.Users);
        }
        public Task<UserAC> GetUser(string userId) {
            throw new NotImplementedException();
        }
        public async Task<UserAC> GetUserByEmailAsync(string userEmail) {
            return _mapper.Map<UserAC>(await _userManager.Users.Where(u => u.Email == userEmail).SingleOrDefaultAsync());
        }
        public async Task<IdentityResult> RegisterUser(RegisterUserAC user) {
            var newUser = new User
            {
                UserFullName = user.UserFullName,
                Email = user.UserEmail,
                UserName = user.UserName,
            };
            var checkUser = await this._userManager.FindByEmailAsync(user.UserEmail);
            if (checkUser == null)
            {
                var result = await this._userManager.CreateAsync(newUser, user.UserPassword);
                if (result.Succeeded)
                {
                    await _context.SaveChangesAsync();
                    return result;
                }
                return result;
            }
            return null;
        }
        public Task UpdateUser(UserAC user) {
            throw new NotImplementedException();
        }
        public Task DeleteUser(UserAC user) {
            throw new NotImplementedException();
        }
        public bool UserExists(string userEmail) {
            throw new NotImplementedException();
        }
    }
}
