using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using PhoneContact.Models;

namespace PhoneContact.DataAccess
{
    public class ContactContext: DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Email> EmailAddresses { get; set; }
        public DbSet<Phone> PhoneNumbers { get; set; }

        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasMany(c => c.PhoneNumbers)
                .WithOne()
                .HasForeignKey(e => e.ContactId);

            modelBuilder.Entity<Contact>()
                .HasMany(c => c.EmailAddresses)
                .WithOne()
                .HasForeignKey(e => e.ContactId);
        }
    }
}
