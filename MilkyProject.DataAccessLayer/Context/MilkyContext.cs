using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MilkyProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.DataAccessLayer.Context
{
    public class MilkyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-91LH8V7\\SQLEXPRESS;initial catalog=MilkyDb;integrated Security=true;TrustServerCertificate=True;");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<About> Abouts { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Gallery> Gallerys { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Testimonial> Tests { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
