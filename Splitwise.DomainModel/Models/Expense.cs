using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Splitwise.DomainModel.Models
{
    class Expense
    {
        public int expenseId { get; set; }
        public string  expenseName { get; set; }
        public double expenseTotalAmount { get; set; }
        public int expenseGroupId { get; set; }
        [ForeignKey("expenseGroupId")]
        public Group expenseGroup { get; set; }
        public string expenseSplitBy { get; set; }
        public string expenseDescription { get; set; }
        public string expenseCurrency { get; set; }
        public string expenseAdderId { get; set; }
        [ForeignKey("expenseAdderId")]
        public User expenseAdder { get; set; }
    }
}
