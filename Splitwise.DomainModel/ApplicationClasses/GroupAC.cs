using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    public class GroupAC
    {
        #region Properties
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupCreatorId { get; set; }
        public UserAC GroupCreator { get; set; }
        #endregion
    }
}
