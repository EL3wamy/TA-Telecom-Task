using Microsoft.EntityFrameworkCore;
using TATelecomTask.configurations;
using TATelecomTask.Domain;

namespace TATelecomTask.Contexts
{
    public class TaskDBContext : DbContext
    {
        public TaskDBContext(DbContextOptions<TaskDBContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; private set; }
        public DbSet<ContactLog> ContactLogs { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactConfiguration())
                        .ApplyConfiguration(new ContactConfiguration());


            base.OnModelCreating(modelBuilder);
        }
    }
}
