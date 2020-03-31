using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Groc.Areas.Identity.Data;
using Groc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Groc.Pages.Shared;
using Groc.AuthorizationHandlers;

namespace Groc.Areas.Orders
{
    [Authorize]
    public class DeleteModel : BasePageModel
    {
        public DeleteModel(Groc.Areas.Identity.Data.GrocIdentityDbContext context,
                UserManager<GroceriesUser> userManager,
                IAuthorizationService authService) : base(context, userManager, authService)
        {
        }

        [BindProperty]
        public OrderHeader Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Order
                .Include(o => o.User).FirstOrDefaultAsync(m => m.Id == id);

            if (Order == null)
            {
                return NotFound();
            }

            var result = await _authorizationService.AuthorizeAsync(User, Order.UserId, OperationRequirements.Create);
            if (!result.Succeeded)
            {
                return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Order.FindAsync(id);

            if (Order != null)
            {
                _context.Order.Remove(Order);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
