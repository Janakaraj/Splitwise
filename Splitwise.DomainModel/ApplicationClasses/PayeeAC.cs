using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    class PayeeAC
    {
        public int Id { get; set; }
        public int expenseId { get; set; }
        public ExpenseAC expense { get; set; }
        public string payeeId { get; set; }
        public UserAC payee { get; set; }
        public double payeeShare { get; set; }
    }
}
