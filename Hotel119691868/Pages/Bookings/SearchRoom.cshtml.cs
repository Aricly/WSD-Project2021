using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel119691868.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        /*public async Task<IActionResult> OnGetAsync()
        {
            int[] bedSize = { 1, 2, 3 };
            ViewData["BedCount"] = bedSize;

            var rooms = (IQueryable<Room>)_context.Room;
            

            rooms = _context.Room.FromSqlRaw("SELECT * FROM Goma.db WHERE BedCount=@Myself.TheRoom.BedCount AND WHERE CheckIn");
            
            Room = await rooms.ToListAsync();
        }*/
    }
}
