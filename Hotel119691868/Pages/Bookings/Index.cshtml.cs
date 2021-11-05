using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hotel119691868.Data;
using Hotel119691868.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Hotel119691868.Pages.Bookings
{
    [Authorize(Roles = "customers")]
    public class IndexModel : PageModel
    {
        private readonly Hotel119691868.Data.ApplicationDbContext _context;

        public IndexModel(Hotel119691868.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; }
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(string sortOrder)
        {
            if (String.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "checkIn_asc";
            }

            //to display and query logged in users bookings
            string _email = User.FindFirst(ClaimTypes.Name).Value;
            var bookings = (IQueryable<Booking>)_context.Booking
                .Include(b => b.TheCustomer)
                .Include(b => b.TheRoom)
                .Where(b => b.CustomerEmail.Contains(_email));

            switch (sortOrder)
            {
                case "checkIn_asc":
                    bookings = bookings.OrderBy(b => b.CheckIn);
                    break;
                case "checkIn_desc":
                    bookings = bookings.OrderByDescending(b => b.CheckIn);
                    break;

                case "cost_asc":
                    bookings = bookings.OrderBy(b => (double)b.Cost);
                    break;
                case "cost_desc":
                    bookings = bookings.OrderByDescending(b => (double)b.Cost);
                    break;

            }

            ViewData["CheckInOrder"] = sortOrder != "checkIn_asc" ? "checkIn_asc" : "checkIn_desc";
            ViewData["CostOrder"] = sortOrder != "cost_asc" ? "cost_asc" : "cost_desc";

            Booking = await bookings.AsNoTracking()
                .Include(s => s.TheRoom).ToListAsync();

            return Page();

        }
    }
}
