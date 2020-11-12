using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Splitwise.DomainModel.Models
{
    public class Payee
    {
        #region Properties
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        [ForeignKey("ExpenseId")]
        public Expense Expense { get; set; }
        public string PayeeId { get; set; }
        [ForeignKey("PayeeId")]
        public User PayeeUser { get; set; }
        public double PayeeShare { get; set; }
        public double PayeeInitialShare { get; set; }
        #endregion
    }
}
