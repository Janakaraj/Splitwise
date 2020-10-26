using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Splitwise.DomainModel.Models
{
    class Friend
    {
        public string userId { get; set; }
        [ForeignKey("userId")]
        public User user { get; set; }
        public string userFriendId { get; set; }
        [ForeignKey("userFriendId")]
        public User userFriend { get; set; }
    }
}
