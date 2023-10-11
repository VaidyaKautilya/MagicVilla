using MagicVilla_VillaAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Data
{
    public class ApplicationDBContext :IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        {
            
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Villa>().HasData( new Villa() 
            { 
                Id=1,
                Name="Royal Villa",
                Details ="This is a test roayal villa",
                ImageUrl = "http://surl.li/kokus",
                Occupation=5,
                Rate=200,
                SqFt=550,
                Aminity="",
                DateCreated= DateTime.Now,
                DateUpdated= DateTime.Now,
            },
             new Villa()
             {
                 Id = 2,
                 Name = "Royal Villa 1",
                 Details = "This is a test roayal villa natural",
                 ImageUrl = "http://surl.li/kokvu",
                 Occupation = 3,
                 Rate = 500,
                 SqFt = 750,
                 Aminity = "",
                 DateCreated = DateTime.Now,
                 DateUpdated = DateTime.Now,
             }
            );
        }
    }
}
