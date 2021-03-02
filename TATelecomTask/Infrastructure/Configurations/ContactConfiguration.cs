using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TATelecomTask.Domain;

namespace TATelecomTask.configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder
                .Property(c => c.MobileNumber)
                .HasMaxLength(15);

            builder
               .HasIndex(c => c.MobileNumber)
               .IsUnique();
        }

    }
}
