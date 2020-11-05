using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Splitwise.DomainModel;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using Splitwise.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.FriendRepository
{
    public class FriendRepository : IFriendRepository
    {
        private readonly IMapper _mapper;
        private readonly SplitwiseDbContext _context;
        private readonly IUserRepository _userRepository;


        public FriendRepository(SplitwiseDbContext _context, IMapper _mapper, IUserRepository userRepository)
        {
            this._context = _context;
            this._mapper = _mapper;
            this._userRepository = userRepository;
        }
        public async Task<UserAC> AddFriend(string userId, string userFriendEmail)
        {
            Friend friend = new Friend();
            friend.Id = 0;
            friend.UserId = userId;
            var user = await this._userRepository.GetUserByEmailAsync(userFriendEmail);
            friend.UserFriendId = user.Id;
            this._context.Friends.Add(friend);
            await _context.SaveChangesAsync();
            return this._mapper.Map<UserAC>(user);
        }
        public bool FriendExistsByEmail(string userId, string userFriendEmail)
        {
            return _context.Friends.Any(e => (e.UserId == userId)&&(e.UserFriend.Email == userFriendEmail));
        }
        public bool FriendExistsById(string userId, string userFriendId)
        {
            return _context.Friends.Any(e => (e.UserId == userId) && (e.UserFriendId == userFriendId));
        }

        public IEnumerable<UserAC> GetFriends(string userId)
        {
            return this._mapper.Map<IEnumerable<UserAC>>(this._context.Friends
                .Where(p => p.UserId == userId)
                .Include(p => p.UserFriend)
                .Select(p => p.UserFriend));
        }

        public async Task<FriendAC> RemoveFriend(string userId, string userFriendId)
        {
                try
                {
                    var friendToRemove = this._context.Friends.Where(e => (e.UserId == userId) && (e.UserFriendId == userFriendId)).FirstOrDefault();
                    this._context.Remove(friendToRemove);
                    await _context.SaveChangesAsync();
                    return this._mapper.Map<FriendAC>(friendToRemove);
                }
                catch(Exception e)
                {
                    return null;
                }
        }
    }
}
