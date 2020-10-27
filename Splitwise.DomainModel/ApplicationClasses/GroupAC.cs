using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    class GroupAC
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public string groupCreatorId { get; set; }
        public UserAC groupCreator { get; set; }
    }
}
