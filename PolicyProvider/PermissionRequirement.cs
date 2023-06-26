


using System;
using Microsoft.AspNetCore.Authorization;

namespace claimbased.PolicyProvider { 

    public class PermissionRequirement : IAuthorizationRequirement
    {
        public static string ClaimType = "id";
        
        // 1 - The operator
        public PermissionOperator PermissionOperator { get; }
        
        // 2 - The list of permissions passed
        public string[] Permissions { get; }

        public PermissionRequirement(
            PermissionOperator permissionOperator, string[] permissions)
        {
            if (permissions.Length == 0)
                throw new ArgumentException("At least one permission is required.", nameof(permissions));

            PermissionOperator = permissionOperator;
            Permissions = permissions;
        }
    }
}