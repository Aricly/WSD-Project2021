using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel119691868.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Hotel119691868.Pages.ManageBookings
{
    [Authorize(Roles = "administrators")]
    public class StatisticsModel : PageModel
    {
        private readonly Hotel119691868.Data.ApplicationDbContext _context;

        public StatisticsModel(Hotel119691868.Data.ApplicationDbContext context)
        {
            _context = context;
        }


        public IList<Statistics> StatisticsStats { get; set; }
        public List<Statistics> StatisticsStats2 { get; private set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var statisticsGroups = _context.Customer.GroupBy(m => m.Postcode);
            StatisticsStats = await statisticsGroups.Select(g => new Statistics { Postcode = g.Key, NumberOfCustomer = g.Count() }).ToListAsync();
            var statisticsGroup2 = _context.Room.GroupBy(m => m.ID);
            StatisticsStats2 = await statisticsGroups.Select(g => new Statistics { RoomID = g.Key, NumberOfBooking = g.Count() }).ToListAsync();
            return Page();
        }

        /*
        public void OnGet()
        {

        }
        */
    }
}
