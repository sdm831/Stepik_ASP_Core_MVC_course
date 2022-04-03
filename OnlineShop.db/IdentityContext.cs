﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.db.Models;

// migration
// Add-Migration InitIdentity -context IdentityContext -OutputDir Migrations/Identity

namespace OnlineShop.db
{
    public class IdentityContext : IdentityDbContext<UserDb>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
            Database.Migrate();
        }
    }
}
