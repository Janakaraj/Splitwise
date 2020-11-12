using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    public class TokenAC
    {
        #region Properties
        public string Token { get; set; }
        public System.DateTime Expiration { get; set; }
        #endregion
    }
}
