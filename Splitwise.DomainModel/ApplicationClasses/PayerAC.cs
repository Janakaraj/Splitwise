using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.DomainModel.ApplicationClasses
{
    public class PayerAC
    {
        #region Properties
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public ExpenseAC Expense { get; set; }
        public string PayerId { get; set; }
        public UserAC PayerUser { get; set; }
        public double AmountPaid { get; set; }
        public double PayerShare { get; set; }
        public double PayerInitialShare { get; set; }
        #endregion
    }
}
