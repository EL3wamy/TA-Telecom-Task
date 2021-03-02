using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TATelecomTask.configurations;
using TATelecomTask.Domain;

namespace TATelecomTask.Contexts
{
    public class TaskDBContext : IdentityDbContext
    {
        public TaskDBContext(DbContextOptions<TaskDBContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; private set; }
        public DbSet<ContactLog> ContactLogs { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactConfiguration())
                        .ApplyConfiguration(new ContactConfiguration());


            base.OnModelCreating(modelBuilder);

            SeedingContacts(modelBuilder);
        }

        private void SeedingContacts(ModelBuilder modelBuilder)
        {
            for (int i = 1; i < 101; i++)
            {
                modelBuilder.Entity<Contact>().HasData(Contact.New($"01060321{i}", i));
            }
        }
    }
}
