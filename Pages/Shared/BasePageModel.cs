using Microsoft.AspNetCore.Mvc.RazorPages;
using Groc.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Groc.Pages.Shared
{
    public class BasePageModel : PageModel
    {
        public readonly Groc.Areas.Identity.Data.GrocIdentityDbContext _context;
        public readonly UserManager<GroceriesUser> _userManager;
        public IAuthorizationService _authorizationService;

        public BasePageModel(Groc.Areas.Identity.Data.GrocIdentityDbContext context,
                UserManager<GroceriesUser> userManager,
                IAuthorizationService authService)
        {
            _context = context;
            _userManager = userManager;
            _authorizationService = authService;
        }

        public async Task<GroceriesUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(User);
    }
}
