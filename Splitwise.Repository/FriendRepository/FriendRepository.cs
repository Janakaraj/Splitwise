﻿using AutoMapper;
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
        #region Private Variables
        private readonly IMapper _mapper;
        private readonly SplitwiseDbContext _context;
        private readonly IUserRepository _userRepository;
        #endregion

        #region Constructors
        public FriendRepository(SplitwiseDbContext _context, IMapper _mapper, IUserRepository userRepository)
        {
            this._context = _context;
            this._mapper = _mapper;
            this._userRepository = userRepository;
        }
        #endregion
        #region Public methods
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

        public async Task<IEnumerable<UserAC>> GetFriends(string userId)
        {
            var users = await this._context.Friends
                .Where(p => p.UserId == userId)
                .Include(p => p.UserFriend)
                .Select(p => p.UserFriend).ToListAsync();
            return this._mapper.Map<IEnumerable<UserAC>>(users);
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
        #endregion
    }
}
