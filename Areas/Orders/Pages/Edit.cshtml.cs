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

namespace Groc.Areas.Orders
{
    public class EditModel : PageModel
    {
        private readonly Groc.Areas.Identity.Data.GrocIdentityDbContext _context;

        public EditModel(Groc.Areas.Identity.Data.GrocIdentityDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; }

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

            var orderFromDb = await _context.Order.Include(oi => oi.OrderLineItem)
                .FirstOrDefaultAsync(x => x.Id == Order.Id);

            var existingLineItem = (orderFromDb.OrderLineItem.FirstOrDefault(x => x.ItemId == NewLineItem.ItemId));
            if (existingLineItem == null)
            {
                NewLineItem.OrderId = orderFromDb.Id;
                orderFromDb.OrderLineItem.Add(NewLineItem);
            }
            else
            {
                existingLineItem.ItemQuantity += NewLineItem.ItemQuantity;
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
