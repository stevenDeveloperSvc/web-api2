using System;
using System.Collections.Generic;

namespace claimbased.Data.Models
{
    public partial class User
    {
        public User()
        {
            Accounts = new HashSet<Account>();
            UserPermissions = new HashSet<UserPermission>();
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime? RegDate { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<UserPermission> UserPermissions { get; set; }
    }
}
