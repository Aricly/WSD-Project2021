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
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Hotel119691868.Pages.Bookings
{
    [Authorize]
    public class CreateModel : PageModel
    {
        public int idle = 0;
        public int available = 1;
        public int unavailable = 2;
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
        public int status { get; set; }


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
            Booking booking1 = await _context.Booking.FirstOrDefaultAsync(m => m.CustomerEmail == _email);

            //calculation for booking price
            var room = await _context.Room.FindAsync(Booking.RoomID);

            int amountOfDays = (int)(Booking.CheckOut - Booking.CheckIn).TotalDays;
            decimal pricePerNight = room.Price;
            Booking.Cost = amountOfDays * pricePerNight;  

            //raw SQL query for bookings to check for interference with booking dates
            var booking = from b in _context.Booking
                          where 
                          (b.CheckIn >= Booking.CheckIn && b.CheckOut <= Booking.CheckOut) ||
                          (b.CheckIn <= Booking.CheckOut && b.CheckOut >= Booking.CheckIn)
                          //(b.CheckIn >= Booking.CheckIn && b.CheckIn <= Booking.CheckOut) ||
                          //(b.CheckOut <= Booking.CheckOut && b.CheckOut >= Booking.CheckIn)
                          select b.RoomID;

            if (booking.Contains(Booking.RoomID))
            {
                status = unavailable;
                return Page();
            }
            
            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();
            status = available;
            ViewData["roomLevel"] = room.Level;
            ViewData["id"] = room.ID;
            ViewData["cost"] = Booking.Cost;
            ViewData["in"] = Booking.CheckIn;
            ViewData["out"] = Booking.CheckOut;
            Booking = new Booking();
            return Page();
        }
    }
}