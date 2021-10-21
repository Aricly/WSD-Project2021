using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hotel119691868.Data;
using Hotel119691868.Models;
using System.Security.Claims;

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

            string _email = User.FindFirst(ClaimTypes.Name).Value;
            Booking.CustomerEmail = _email;
            var room = await _context.Room.FindAsync(Booking.RoomID);
            int days = (int)(this.Booking.CheckOut - this.Booking.CheckIn).TotalDays;

            int amountOfDays = (int)(Booking.CheckOut - Booking.CheckIn).TotalDays;
            decimal pricePerNight = room.Price;
            Booking.Cost = amountOfDays * pricePerNight;

            var bookings = from b in _context.Booking
                           where (b.CheckIn >= Booking.CheckIn &&
                           b.CheckIn <= Booking.CheckOut) ||
                           (b.CheckOut <= Booking.CheckOut &&
                           b.CheckOut >= Booking.CheckIn)
                           select b.RoomID;

            if (bookings.Contains(this.Booking.RoomID))
            {
                //BookingStatus = (int)Status.unavailable;
                Booking = new Models.Booking();
                return Page();
            }

            _context.Booking.Add(Booking);
            ViewData["level"] = room.Level;
            ViewData["cost"] = Booking.Cost;
            ViewData["roomID"] = Booking.RoomID;
            await _context.SaveChangesAsync();
            //BookingStatus = (int)Status.available;
            Booking = new Models.Booking();

            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
