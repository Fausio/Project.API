using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.API.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.Config
{
    public class ContextBaseApp : IdentityDbContext<ApplicationUser>
    {

        public ContextBaseApp(DbContextOptions<ContextBaseApp> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .ToTable("AspNetUsers")
                .HasKey(e => e.Id);

            base.OnModelCreating(builder);
        }

        private string ConnectionString() => "Data Source=localhost;Initial Catalog=Poject_API;Integrated Security=True;  Persist Security Info=False; User ID=sa; Password=0l0ga;Encrypt=False;TrusrServerCertificate=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString());
                base.OnConfiguring(optionsBuilder);
            }
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
