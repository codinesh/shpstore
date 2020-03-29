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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Groc.Areas.Orders
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly GrocIdentityDbContext _context;
        private readonly UserManager<GroceriesUser> _userManager;

        public CreateModel(GrocIdentityDbContext context,
                           UserManager<GroceriesUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
            Order.User = await _userManager.GetUserAsync(User);
            Order.UserId = Order.User.Id;
            Order.Created = DateTime.UtcNow;
            Order.CreatedBy = Order.UserId;
            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            var latestOrder = await _context.Order.OrderByDescending(x => x.Id).FirstOrDefaultAsync(x => x.UserId == Order.UserId);

            return RedirectToPage("Edit", new { latestOrder.Id });
        }
    }
}
