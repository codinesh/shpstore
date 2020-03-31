using Groc.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Groc.AuthorizationHandlers
{
    public class UserAuthHandler
                    : AuthorizationHandler<OperationAuthorizationRequirement, int>
    {
        UserManager<GroceriesUser> _userManager;

        public UserAuthHandler(UserManager<GroceriesUser> userManager)
        {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, int ownerId)
        {
            if (context.User == null || ownerId <= 0)
            {
                return Task.CompletedTask;
            }

            // Administrators can do anything.
            if (ownerId.ToString() == _userManager.GetUserId(context.User))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
