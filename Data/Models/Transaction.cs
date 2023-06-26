using System;
using System.Collections.Generic;

namespace claimbased.Data.Models
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int TransactionType { get; set; }
        public decimal Amount { get; set; }
        public int? ExternalAccount { get; set; }
        public DateTime RegDate { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual TransactionType TransactionTypeNavigation { get; set; } = null!;
    }
}
