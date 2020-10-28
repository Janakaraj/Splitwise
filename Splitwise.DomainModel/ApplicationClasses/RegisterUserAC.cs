using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    public class RegisterUserAC
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public string UserPhoneNumber { get; set; }
    }
}
