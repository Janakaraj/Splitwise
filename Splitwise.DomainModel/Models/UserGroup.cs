using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Splitwise.DomainModel.Models
{
    public class UserGroup
    {
        public int Id { get; set; }
        public string userId { get; set; }
        [ForeignKey("userId")]
        public User user { get; set; }
        public int groupId { get; set; }
        [ForeignKey("groupId")]
        public Group group { get; set; }
    }
}
