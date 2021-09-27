using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Hotel119691868.Models;

namespace Hotel119691868.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Hotel119691868.Models.Room> Room { get; set; }
        public DbSet<Hotel119691868.Models.Customer> Customer { get; set; }
        public DbSet<Hotel119691868.Models.Booking> Booking { get; set; }
    }
}
