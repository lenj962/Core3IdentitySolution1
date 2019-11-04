using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Core3ID.Domain;

namespace Core3Identity.DataAccess
{
    public class Core3IDContext : IdentityDbContext<Core3IDUser>
    {
        public Core3IDContext(DbContextOptions<Core3IDContext> options) : base(options)
        {
        } // end public Core3IDContext(DbContextOptions<FREEIncContext> options) : base(options)

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Core3IDUser>()
                .Property(u => u.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Entity<Core3IDUser>()
                    .Property(u => u.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

        } // end protected override void OnModelCreating(ModelBuilder builder)
    } // end public class Core3IDContext : IdentityDbContext<Core3IDUser>
} // end namespace Core3Identity.DataAccess
