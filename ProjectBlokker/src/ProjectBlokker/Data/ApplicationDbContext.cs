using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectBlokker.Models;

namespace ProjectBlokker.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // Default constructor nodig om te kunnen mocken
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        // Property is virtual om te kunnen mocken.
        public virtual DbSet<Afspraak> Afspraak { get; set; }

        public virtual DbSet<Artikel> Artikel { get; set; }
        public virtual DbSet<Categorie> Categorie { get; set; }
        public virtual DbSet<Jurk> Jurk { get; set; }
        public virtual DbSet<Merk> Merk { get; set; }
        public virtual DbSet<Neklijn> Neklijn { get; set; }
        public virtual DbSet<Stijl> Stijl { get; set; }
    }
}
