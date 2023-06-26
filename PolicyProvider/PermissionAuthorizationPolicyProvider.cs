using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;


namespace claimbased.PolicyProvider{



    public class PermissionAuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
    {
        public PermissionAuthorizationPolicyProvider(
            IOptions<AuthorizationOptions> options) : base(options) { }

        public override async Task<AuthorizationPolicy?> GetPolicyAsync(
            string policyName)
        {
            if (!policyName.StartsWith(PolicyPrefix, StringComparison.OrdinalIgnoreCase))
                return await base.GetPolicyAsync(policyName);

            // Will extract the Operator AND/OR enum from the string
            PermissionOperator @operator = GetOperatorFromPolicy(policyName);

            // Will extract the permissions from the string (Create, Update..)
            string[] permissions = GetPermissionsFromPolicy(policyName);

            // Here we create the instance of our requirement
            var requirement = new PermissionRequirement(@operator, permissions);

            // Now we use the builder to create a policy, adding our requirement
            return new AuthorizationPolicyBuilder()
                .AddRequirements(requirement).Build();
        }
    }
}