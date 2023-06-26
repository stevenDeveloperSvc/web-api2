using System;
using System.Collections.Generic;

namespace claimbased.Data.Models
{
    public partial class AccountType
    {
        public AccountType()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
