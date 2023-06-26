using System;
using System.Collections.Generic;

namespace claimbased.Data.Models
{
    public partial class RoleType
    {
        public RoleType()
        {
            UserPermissions = new HashSet<UserPermission>();
        }

        public int Id { get; set; }
        public string? RoleName { get; set; }

        public virtual ICollection<UserPermission> UserPermissions { get; set; }
    }
}
