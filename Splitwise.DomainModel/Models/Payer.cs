using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Splitwise.DomainModel.Models
{
    public class Payer
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        [ForeignKey("ExpenseId")]
        public Expense Expense { get; set; }
        public string PayerId { get; set; }
        [ForeignKey("PayerId")]
        public User PayerUser { get; set; }
        public double AmountPaid { get; set; }
        public double PayerShare { get; set; }
        public double PayerInitialShare { get; set; }
    }
}
