using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    public class PayeeAC
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public ExpenseAC Expense { get; set; }
        public string PayeeId { get; set; }
        public UserAC PayeeUser { get; set; }
        public double PayeeShare { get; set; }
        public double PayeeInitialShare { get; set; }
    }
}
