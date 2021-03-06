using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Groc.Areas.Identity.Data;
using Groc.Models;
using Microsoft.AspNetCore.Authorization;
using Groc.Pages.Shared;
using Microsoft.AspNetCore.Identity;

namespace Groc.Areas.Orders
{
    [Authorize]
    public class EditModel : BasePageModel
    {
        public EditModel(Groc.Areas.Identity.Data.GrocIdentityDbContext context,
                 UserManager<GroceriesUser> userManager,
                 IAuthorizationService authService) : base(context, userManager, authService)
        {
        }

        [BindProperty]
        public OrderHeader Order { get; set; }

        [BindProperty]
        public OrderLineItem NewLineItem { get; set; }

        public List<OrderLineItem> LineItems { get; set; }
        public SelectList AvailableInventory { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Order
                .Include(o => o.OrderLineItem)
                .FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted);

            if (Order == null)
            {
                return NotFound();
            }

            LineItems = Order.OrderLineItem ?? new List<OrderLineItem>();
            var availableInventoryQuery = from d in _context.Inventory
                                          orderby d.Name // Sort by name.
                                          select d;
            var list = availableInventoryQuery.ToList();
            ViewData["AvailableInventory"] = new SelectList(availableInventoryQuery.AsNoTracking(),
                        "Id", "Name");
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

            var orderFromDb = await _context.Order
                .Include(oi => oi.OrderLineItem)
                .FirstOrDefaultAsync(x => x.Id == Order.Id);
            var inventoryItem = await _context.Inventory.FirstOrDefaultAsync(i => i.Id == NewLineItem.ItemId);
            var existingLineItem = (orderFromDb.OrderLineItem.FirstOrDefault(x => x.ItemId == NewLineItem.ItemId));
            if (existingLineItem == null)
            {
                NewLineItem.OrderId = orderFromDb.Id;
                NewLineItem.Price = NewLineItem.ItemQuantity * inventoryItem.PricePerUnit;
                orderFromDb.OrderLineItem.Add(NewLineItem);
            }
            else
            {
                existingLineItem.ItemQuantity += NewLineItem.ItemQuantity;
                existingLineItem.Price = existingLineItem.ItemQuantity * inventoryItem.PricePerUnit;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Edit", new { Order.Id });
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }
}
