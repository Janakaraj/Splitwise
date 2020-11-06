using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    public class ExpenseAC
    {
        public int ExpenseId { get; set; }
        public string ExpenseName { get; set; }
        public double ExpenseTotalAmount { get; set; }
        public int ExpenseGroupId { get; set; }
        public GroupAC ExpenseGroup { get; set; }
        public string ExpenseSplitBy { get; set; }
        public string ExpenseDescription { get; set; }
        public string ExpenseCurrency { get; set; }
        public string ExpenseAddTimeStamp { get; set; }
        public string ExpenseAdderId { get; set; }
        public UserAC ExpenseAdder { get; set; }
    }
}
