using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    public class PayerAC
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public ExpenseAC Expense { get; set; }
        public string PayerId { get; set; }
        public UserAC PayerUser { get; set; }
        public double AmountPaid { get; set; }
    }
}
