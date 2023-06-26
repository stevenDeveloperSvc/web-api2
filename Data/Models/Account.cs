using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace claimbased.Data.Models
{
    public partial class Account
    {
        public Account()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public int AccountTypeId { get; set; }
        public int? UserId { get; set; }
        public decimal Balance { get; set; }
        public DateTime RegDate { get; set; }

        public virtual AccountType AccountType { get; set; } = null!;
        public virtual Client? User { get; set; }
        public virtual User? UserNavigation { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
