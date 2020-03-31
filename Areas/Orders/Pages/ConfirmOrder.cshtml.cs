using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Groc.Areas.Identity.Data;
using Groc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Groc.Pages.Shared;
using Groc.AuthorizationHandlers;

namespace Groc.Areas.Orders
{

    [Authorize]
    public class ConfirmOrderModel : BasePageModel
    {
        public ConfirmOrderModel(Groc.Areas.Identity.Data.GrocIdentityDbContext context,
                UserManager<GroceriesUser> userManager,
                IAuthorizationService authService) : base(context, userManager, authService)
        {
        }

        [BindProperty]
        public OrderHeader Order { get; set; }

        public List<OrderLineItem> LineItems { get; set; }

        public bool DetailsMode { get; set; }

        public string UserName { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Order = await _context.Order
                .Include(o => o.OrderLineItem)
                    .ThenInclude(ol => ol.Item)
                .FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted);
            if (Order == null)
            {
                return NotFound();
            }

            var result = await _authorizationService.AuthorizeAsync(User, Order.UserId, OperationRequirements.Create);
            if (!result.Succeeded)
            {
                return Forbid();
            }

            var user = await GetCurrentUserAsync();
            UserName = user.Name;
            LineItems = Order.OrderLineItem ?? new List<OrderLineItem>();
            Order.OrderTotal = Order.OrderLineItem.Sum(x => x.Price);
            DetailsMode = Order.Status != OrderStatus.InProgress;
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var orderFromDb = await _context.Order.FirstOrDefaultAsync(x => x.Id == Order.Id);

            if (orderFromDb == null)
            {
                return NotFound();
            }

            var result = await _authorizationService.AuthorizeAsync(User, orderFromDb.UserId, OperationRequirements.Create);
            if (!result.Succeeded)
            {
                return Forbid();
            }

            orderFromDb.Status = OrderStatus.PendingPayment;
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
