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

namespace Groc.Areas.Orders
{
    public class CreateModel : PageModel
    {
        private readonly Groc.Areas.Identity.Data.GrocIdentityDbContext _context;

        public CreateModel(Groc.Areas.Identity.Data.GrocIdentityDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Order.UserId = 1;
            Order.Created = DateTime.UtcNow;
            Order.CreatedBy = Order.UserId;
            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            var latestOrder = await _context.Order.OrderByDescending(x => x.Id).FirstOrDefaultAsync(x => x.UserId == Order.UserId);

            return RedirectToPage("Edit", new { latestOrder.Id });
        }
    }
}
