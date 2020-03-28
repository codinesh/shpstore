using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Groc.Areas.Identity.Data;
using Groc.Models;

namespace Groc.Areas.Orders
{
    public class IndexModel : PageModel
    {
        private readonly Groc.Areas.Identity.Data.GrocIdentityDbContext _context;

        public IndexModel(Groc.Areas.Identity.Data.GrocIdentityDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Orders
                .Include(o => o.User).ToListAsync();
        }
    }
}
