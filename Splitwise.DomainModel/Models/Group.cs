using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Splitwise.DomainModel.Models
{
    public class Group
    {
        #region Properties
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupCreatorId { get; set; }
        [ForeignKey("GroupCreatorId")]
        public User GroupCreator { get; set; }
        #endregion
    }
}
