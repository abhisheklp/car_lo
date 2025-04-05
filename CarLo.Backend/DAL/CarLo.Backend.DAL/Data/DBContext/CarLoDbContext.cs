using CarLo.Backend.DAL.Entities;
using CarLo.Backend.DAL.IdentityUseExtented;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarLo.Backend.DAL.Data.DBContext
{
    public class CarLoDbContext : IdentityDbContext<ApplicationUser>
    {
        public CarLoDbContext(DbContextOptions<CarLoDbContext> options) : base(options) {}

        public DbSet<CarDetailsEntity> CarDetails { get; set; }

        public DbSet<CarCategoryEntity> CarCategories { get; set; }

        public DbSet<RentalAgreementEntity> RentalAgreementDetails { get; set; }

        public DbSet<ReturnRequestEntity> ReturnRequestDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" });

            var hasher = new PasswordHasher<IdentityUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                    UserName = "abhishek@nagarro.com",
                    NormalizedUserName = "ABHISHEK@NAGARRO.COM",
                    PhoneNumber = "9157806213",
                    Email = "abhishek@nagarro.com",
                    NormalizedEmail = "ABHISHEK@NAGARRO.COM",
                    PasswordHash = hasher.HashPassword(null, "@Ab123456"),
                    FullName = "Abhishek Pandey Admin",
                    isAdmin = true
                },
                new ApplicationUser
                {
                    Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserName = "abhishek@gmail.com",
                    NormalizedUserName = "ABHISHEK@GMAIL.COM",
                    PhoneNumber = "0123456789",
                    Email = "abhishek@gmail.com",
                    NormalizedEmail = "ABHISHEK@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "@Ab123456"),
                    FullName = "Abhishek Pandey User",
                    isAdmin = false
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "1",
                    UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                }
            );
        }
    }
}
