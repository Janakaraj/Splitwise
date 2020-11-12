using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    public class SettlementAC
    {
        #region Properties
        public int SettlementId { get; set; }
        public int? SettlementGroupId { get; set; }
        public GroupAC Group { get; set; }
        public string UserPayingId { get; set; }
        public UserAC UserPaying { get; set; }
        public string UserRecievingId { get; set; }
        public UserAC UserRecieving { get; set; }
        public int SettlementExpenseId { get; set; }
        public ExpenseAC SettlementExpense { get; set; }
        public double TransactionAmount { get; set; }
        #endregion
    }
}
