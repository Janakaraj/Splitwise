using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Splitwise.DomainModel.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public string  ExpenseName { get; set; }
        public double ExpenseTotalAmount { get; set; }
        public int ExpenseGroupId { get; set; }
        [ForeignKey("ExpenseGroupId")]
        public Group ExpenseGroup { get; set; }
        public string ExpenseSplitBy { get; set; }
        public string ExpenseDescription { get; set; }
        public string ExpenseCurrency { get; set; }
        public string ExpenseAddTimeStamp { get; set; }
        public string ExpenseAdderId { get; set; }
        [ForeignKey("ExpenseAdderId")]
        public User ExpenseAdder { get; set; }
    }
}
