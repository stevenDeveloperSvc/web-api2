using System;
using System.Collections.Generic;

namespace claimbased.Data.Models
{
    public partial class UserPermission
    {
        public int Id { get; set; }
        public int? Userid { get; set; }
        public int? RoleTypeid { get; set; }
        public int? PermissionType { get; set; }

        public virtual PermissionType? PermissionTypeNavigation { get; set; }
        public virtual RoleType? RoleType { get; set; }
        public virtual User? User { get; set; }
    }
}
