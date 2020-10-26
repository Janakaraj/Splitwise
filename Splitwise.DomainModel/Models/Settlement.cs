using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Splitwise.DomainModel.Models
{
    class Settlement
    {
        public int settlementId { get; set; }
        public int settlementGroupId { get; set; }
        [ForeignKey("settlementGroupId")]
        public Group group { get; set; }
        public string userPayingId { get; set; }
        [ForeignKey("userPayingId")]
        public User userPaying { get; set; }
        public string userRecievingId { get; set; }
        [ForeignKey("userRecievingId")]
        public User userRecieving { get; set; }
        public int settlementExpenseId { get; set; }
        [ForeignKey("settlementExpenseId")]
        public Expense settlementExpense { get; set; }
        public double transactionAmount { get; set; }

    }
}
