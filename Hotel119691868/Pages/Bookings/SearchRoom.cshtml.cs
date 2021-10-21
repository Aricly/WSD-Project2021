using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel119691868.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Hotel119691868.Pages.Bookings
{
    public class SearchRoomModel : PageModel
    {
        private readonly Hotel119691868.Data.ApplicationDbContext _context;

        public SearchRoomModel(Hotel119691868.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Myself { get; set; }
        public IList<Room> Room { get; set; }
        public IActionResult OnGet()
        {
            ViewData["Submitted"] = "False";

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var rooms = (IQueryable<Room>)_context.Room;
            var booking = from b in _context.Booking
                          where (Myself.CheckOut <= b.CheckIn || b.CheckOut <= Myself.CheckIn)
                          select b.RoomID;

            var rum = new SqliteParameter("Roomnum", booking.ToString());
            var beds = new SqliteParameter("Beds", Myself.TheRoom.BedCount.ToString());
            var bookIn = new SqliteParameter("BookIn", Myself.CheckIn.ToString());
            var bookOut = new SqliteParameter("BookOut", Myself.CheckOut.ToString());

            rooms = _context.Room.FromSqlRaw("SELECT * FROM Room WHERE BedCount = @Beds AND ID NOT IN (SELECT RoomID FROM Booking WHERE @BookOut <= CheckIn OR CheckOut <= @BookIn)"    
                                                , beds, rum, bookOut, bookIn);
            Room = await rooms.ToListAsync();

            ViewData["Submitted"] = "True";
            return Page();
        }
    }
}
