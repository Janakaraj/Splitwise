using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Splitwise.DomainModel.Models
{
    class Payee
    {
        public int expenseId { get; set; }
        [ForeignKey("expenseId")]
        public Expense expense { get; set; }
        public string payeeId { get; set; }
        [ForeignKey("payeeId")]
        public User payee { get; set; }
        public double payeeShare { get; set; }
    }
}
