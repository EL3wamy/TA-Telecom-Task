using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TATelecomTask.Domain;

namespace TATelecomTask.Configurations
{
    public class ContactLogConfiguration : IEntityTypeConfiguration<ContactLog>
    {
        public void Configure(EntityTypeBuilder<ContactLog> builder)
        {
            builder.Property(cl => cl.Message)
                .HasMaxLength(512)
                .IsRequired();

            builder.HasOne(cl => cl.Contact);
        }
    }
}
