using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    class SettlementAC
    {
        public int settlementId { get; set; }
        public int? settlementGroupId { get; set; }
        public GroupAC group { get; set; }
        public string userPayingId { get; set; }
        public UserAC userPaying { get; set; }
        public string userRecievingId { get; set; }
        public UserAC userRecieving { get; set; }
        public int settlementExpenseId { get; set; }
        public ExpenseAC settlementExpense { get; set; }
        public double transactionAmount { get; set; }
    }
}
