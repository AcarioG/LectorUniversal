using Duende.IdentityServer.EntityFramework.Options;
using LectorUniversal.Server.Models;
using LectorUniversal.Shared;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LectorUniversal.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext( DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BooksGender>().HasKey(g => new { g.GenderId, g.BookId });
            builder.Entity<Book>().HasMany(c => c.Chapters).WithOne(b => b.Books).HasForeignKey(b => b.BooksId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Chapter>().HasMany(p => p.ChapterPages).WithOne(c => c.Chapter).HasForeignKey(c => c.ChapterId).OnDelete(DeleteBehavior.Cascade);


            var roleAdmin = 
                new IdentityRole()
                { 
                    Id = "6964fafb-f35f-4e02-b54b-c88aae976d0a", 
                    Name = "admin",
                    NormalizedName = "admin" 
                };

            var defaultRole = new IdentityRole() 
            { 
                Id = "7f9f3a7e-9bc6-4b14-943f-bf924b00f05d",
                Name="default",
                NormalizedName = "default"
            };

            var userAdmin = new ApplicationUser() 
            { Id = "7f10bef8-3d68-4a7d-8262-7846e339e7d2", UserName = "AcarioG", NormalizedUserName = "ACARIOG", Email = "wilmervasquez219@gmail.com",
                NormalizedEmail="WILMERVASQUEZ219@GMAIL.COM", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAENyGMozmIMj3qkPBGtXK6uq+LtRPpYIKrwHenak+3N1YwR0QhffQS1TrcA05HRz8bg==",
                SecurityStamp= "XAAIWXV5PF3EPASY7ONECLRUAPKWSUBY", ConcurrencyStamp= "bfb6ef6e-e803-4a81-bc55-edbdbe25be53", PhoneNumber="8297500421",
                PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnd = null, LockoutEnabled= true, AccessFailedCount = 0   };

            var roleUser = new IdentityUserRole<string>() { RoleId = "6964fafb-f35f-4e02-b54b-c88aae976d0a", UserId = "7f10bef8-3d68-4a7d-8262-7846e339e7d2" };

            builder.Entity<IdentityRole>().HasData(roleAdmin,defaultRole);
            builder.Entity<ApplicationUser>().HasData(userAdmin);
            builder.Entity<IdentityUserRole<string>>().HasData(roleUser);






            base.OnModelCreating(builder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Shared.Pages> Pages { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<BooksGender> GenderBooks { get; set; }
    }
}