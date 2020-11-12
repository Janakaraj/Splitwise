using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    public class FriendAC
    {
        #region Properties
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserAC User { get; set; }
        public string UserFriendId { get; set; }
        public UserAC UserFriend { get; set; }
        #endregion
    }
    public class AddFriendAC
    {
        #region Properties
        public string UserId { get; set; }
        public string UserFriendEmail { get; set; }
        #endregion
    }
    public class RemoveFriendAC
    {
        #region Properties
        public string UserId { get; set; }
        public string UserFriendId { get; set; }
        #endregion
    }
}
