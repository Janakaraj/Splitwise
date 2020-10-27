using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    class userGroupAC
    {
        public int Id { get; set; }
        public int groupId { get; set; }
        public GroupAC group { get; set; }
        public string userId { get; set; }
        public UserAC user { get; set; }
    }
}
