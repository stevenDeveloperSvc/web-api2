using System;
using System.Collections.Generic;

namespace claimbased.Data.Models
{
    public partial class PermissionType
    {
        public PermissionType()
        {
            UserPermissions = new HashSet<UserPermission>();
        }

        public int Id { get; set; }
        public string? PermissionTypeName { get; set; }

        public virtual ICollection<UserPermission> UserPermissions { get; set; }
    }
}
