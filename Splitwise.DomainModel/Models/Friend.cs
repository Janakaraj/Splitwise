using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Splitwise.DomainModel.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public string userId { get; set; }
        [ForeignKey("userId")]
        public User user { get; set; }
        public string userFriendId { get; set; }
        [ForeignKey("userFriendId")]
        public User userFriend { get; set; }
    }
}
