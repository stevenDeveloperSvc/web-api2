using System;
using System.Collections.Generic;

namespace claimbased.Data.Models
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime RegDate { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
