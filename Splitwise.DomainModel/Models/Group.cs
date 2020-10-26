using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Splitwise.DomainModel.Models
{
    public class Group
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public string groupCreatorId { get; set; }
        [ForeignKey("groupCreatorId")]
        public User groupCreator { get; set; }
    }
}
