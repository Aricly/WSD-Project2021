using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hotel119691868.Data;
using Hotel119691868.Models;

namespace Hotel119691868.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly Hotel119691868.Data.ApplicationDbContext _context;

        public IndexModel(Hotel119691868.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customer.ToListAsync();
        }
    }
}
