using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Hotel119691868.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Hotel119691868.Pages.Customers
{
    [Authorize(Roles = "customers")]
    public class MyDetailsModel : PageModel
    {
        private readonly Hotel119691868.Data.ApplicationDbContext _context;

        public MyDetailsModel(Hotel119691868.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomerViewModel Myself { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            string _email = User.FindFirst(ClaimTypes.Name).Value;

            Customer customer = await _context.Customer.FirstOrDefaultAsync(m => m.Email == _email);

            if (customer != null)
            {
                ViewData["ExistInDB"] = "true";
                Myself = new CustomerViewModel
                {
                    FirstName = customer.GivenName,
                    LastName = customer.Surname,
                    Postcode = customer.Postcode,
                };
            }
            else
            {
                ViewData["ExistInDB"] = "false";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string _email = User.FindFirst(ClaimTypes.Name).Value;

            Customer customer = await _context.Customer.FirstOrDefaultAsync(m => m.Email == _email);

            if (customer != null)
            {
                ViewData["ExistInDB"] = "true";
            }
            else
            {
                ViewData["ExistInDB"] = "false";
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (customer == null)
            {
                customer = new Customer();
            }

            customer.Email = _email;
            customer.GivenName = Myself.FirstName;
            customer.Surname = Myself.LastName;
            customer.Postcode = Myself.Postcode;

            if ((string)ViewData["ExistInDB"] == "true")
            {
                _context.Attach(customer).State = EntityState.Modified;
            }
            else
            {
                _context.Customer.Add(customer);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            ViewData["SuccessDB"] = "success";
            return Page();
        }

    }
}
