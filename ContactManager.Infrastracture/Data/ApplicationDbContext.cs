using ContactManager.Domain.Entities.Contacts;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Contact> Contacts => Set<Contact>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
