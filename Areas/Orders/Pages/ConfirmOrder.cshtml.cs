using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Groc.Areas.Identity.Data;
using Groc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Groc.Areas.Orders
{
    [Authorize]
    public class ConfirmOrderModel : PageModel
    {
        private readonly Groc.Areas.Identity.Data.GrocIdentityDbContext _context;
        private readonly UserManager<GroceriesUser> _userManager;

        public ConfirmOrderModel(Groc.Areas.Identity.Data.GrocIdentityDbContext context, UserManager<GroceriesUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Order Order { get; set; }

        public List<OrderLineItem> LineItems { get; set; }

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
            var user = await _userManager.GetUserAsync(User);
            UserName = user.Name;
            LineItems = Order.OrderLineItem ?? new List<OrderLineItem>();
            Order.OrderTotal = Order.OrderLineItem.Sum(x => x.Price);
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
            orderFromDb.Status = OrderStatus.PendingPayment;
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
