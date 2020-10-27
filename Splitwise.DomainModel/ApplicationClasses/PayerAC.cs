using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    class PayerAC
    {
        public int Id { get; set; }
        public int expenseId { get; set; }
        public ExpenseAC expense { get; set; }
        public string payerId { get; set; }
        public UserAC payer { get; set; }
        public double amountPaid { get; set; }
    }
}
