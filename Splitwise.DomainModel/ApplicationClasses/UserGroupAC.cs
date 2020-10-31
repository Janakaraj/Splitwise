using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    public class UserGroupAC
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public GroupAC Group { get; set; }
        public string UserId { get; set; }
        public UserAC User { get; set; }
    }
}
