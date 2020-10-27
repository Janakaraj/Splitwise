using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    class ExpenseAC
    {
        public int expenseId { get; set; }
        public string expenseName { get; set; }
        public double expenseTotalAmount { get; set; }
        public int expenseGroupId { get; set; }
        public GroupAC expenseGroup { get; set; }
        public string expenseSplitBy { get; set; }
        public string expenseDescription { get; set; }
        public string expenseCurrency { get; set; }
        public string expenseAdderId { get; set; }
        public UserAC expenseAdder { get; set; }
    }
}
