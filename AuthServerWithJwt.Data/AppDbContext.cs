using AuthServerWithJwt.Core.Models;
using AuthServerWithJwt.Data.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServerWithJwt.Data
{
    public class AppDbContext:IdentityDbContext<UserApp,IdentityRole,string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Product> Produscts { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // tüm configureleri tek bir defada ekler.
            //builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new UserAppConfiguration());
            builder.ApplyConfiguration(new UserRefreshTokenConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
