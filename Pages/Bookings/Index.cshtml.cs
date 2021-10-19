using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hotel119691868.Data;
using Hotel119691868.Models;

namespace Hotel119691868.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly Hotel119691868.Data.ApplicationDbContext _context;

        public IndexModel(Hotel119691868.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; }

        public async Task OnGetAsync()
        {
            Booking = await _context.Booking
                .Include(b => b.TheCustomer)
                .Include(b => b.TheRoom).ToListAsync();
        }
    }
}
