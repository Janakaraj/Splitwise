using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Splitwise.DomainModel.Models
{
    public class Payer
    {
        public int Id { get; set; }
        public int expenseId { get; set; }
        [ForeignKey("expenseId")]
        public Expense expense { get; set; }
        public string payerId { get; set; }
        [ForeignKey("payerId")]
        public User payer { get; set; }
        public double amountPaid { get; set; }
    }
}
