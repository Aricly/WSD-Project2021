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
            List<int> bedSize = new List<int>();
            bedSize.Add(1);
            bedSize.Add(2);
            bedSize.Add(3);

            IEnumerable<int> list = bedSize;
            ViewData["BedCount"] = list;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            //var rooms = (IQueryable<Booking>)_context.Booking;
            var rooms = (IQueryable<Room>)_context.Room;
            /*
            var bookIn = new SqliteParameter("BookIn", Myself.CheckIn);
            var bookOut = new SqliteParameter("BookOut", Myself.CheckOut);
            var beds = new SqliteParameter("Beds", Myself.TheRoom.BedCount);
            */
            var booking = from b in _context.Booking
                          where (Myself.CheckOut <= b.CheckIn || b.CheckOut <= Myself.CheckIn)      /*(b.CheckIn >= Myself.CheckIn && b.CheckOut <= Myself.CheckOut) || (b.CheckIn <= Myself.CheckOut && b.CheckOut >= Myself.CheckIn)*/
                          select b.RoomID;

            /*rooms = _context.Booking.FromSqlRaw("SELECT * FROM Booking WHERE RoomID = (SELECT ID FROM Room WHERE BedCount = @Beds) "
                                                + "AND WHERE @Bookout <= CheckIn OR WHERE CheckOut <= @BookIn", beds, bookOut, bookIn);
            */
            var rum = new SqliteParameter("Room", booking.ToString());
            rooms = _context.Room.FromSqlRaw("SELECT * FROM Room WHERE ID = @Room", rum);
            Room = await rooms.ToListAsync();

            ViewData["Submitted"] = "True";
            return Page();
        }
    }
}
