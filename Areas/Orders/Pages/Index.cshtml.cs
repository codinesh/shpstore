using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Groc.Areas.Identity.Data;
using Groc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Groc.Areas.Orders
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Groc.Areas.Identity.Data.GrocIdentityDbContext _context;
        private readonly UserManager<GroceriesUser> _userManager;

        public IndexModel(Groc.Areas.Identity.Data.GrocIdentityDbContext context, UserManager<GroceriesUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Order> Order { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            Order = await _context.Order
                .Include(o => o.User)
                .Where(x => x.UserId == user.Id && !x.IsDeleted)
                .ToListAsync();
        }
    }
}
