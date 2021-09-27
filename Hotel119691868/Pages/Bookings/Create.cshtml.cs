using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hotel119691868.Data;
using Hotel119691868.Models;

namespace Hotel119691868.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly Hotel119691868.Data.ApplicationDbContext _context;

        public CreateModel(Hotel119691868.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        //ViewData["CustomerEmail"] = new SelectList(_context.Customer, "Email", "Email");
        ViewData["RoomID"] = new SelectList(_context.Room, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
