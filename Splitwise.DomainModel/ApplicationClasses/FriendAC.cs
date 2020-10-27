using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    public class FriendAC
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserAC User { get; set; }
        public string UserFriendId { get; set; }
        public UserAC UserFriend { get; set; }
    }
}
