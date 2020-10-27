using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    class FriendAC
    {
        public int Id { get; set; }
        public string userId { get; set; }
        public UserAC user { get; set; }
        public string userFriendId { get; set; }
        public UserAC userFriend { get; set; }
    }
}
