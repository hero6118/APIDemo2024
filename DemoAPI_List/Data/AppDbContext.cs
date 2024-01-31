using DemoAPI_List.Models;
using DemoAPI_List.Models.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DemoAPI_List.Data
{
    
        public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }
            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
            }

        public DbSet<Product> Products { get; set; }
        }
    
}
