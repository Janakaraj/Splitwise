using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Splitwise.DomainModel.Models
{
    public class Settlement
    {
        public int SettlementId { get; set; }
        public int? SettlementGroupId { get; set; }
        [ForeignKey("SettlementGroupId")]
        public Group Group { get; set; }
        public string UserPayingId { get; set; }
        [ForeignKey("UserPayingId")]
        public User UserPaying { get; set; }
        public string UserRecievingId { get; set; }
        [ForeignKey("UserRecievingId")]
        public User UserRecieving { get; set; }
        public int SettlementExpenseId { get; set; }
        [ForeignKey("SettlementExpenseId")]
        public Expense SettlementExpense { get; set; }
        public double TransactionAmount { get; set; }

    }
}
