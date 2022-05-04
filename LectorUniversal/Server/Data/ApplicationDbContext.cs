using Duende.IdentityServer.EntityFramework.Options;
using LectorUniversal.Server.Models;
using LectorUniversal.Shared;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
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
            //builder.Entity<ChapterPages>().HasKey(c => new { c.PageId, c.ChapterId });

            base.OnModelCreating(builder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Shared.Pages> Pages { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<BooksGender> GenderBooks { get; set; }
        //public DbSet<ChapterPages> ChapterPages { get; set; }
    }
}