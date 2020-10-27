using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.Models
{
    public class User : IdentityUser
    {
        public string UserFullName { get; set; }
    }
}
