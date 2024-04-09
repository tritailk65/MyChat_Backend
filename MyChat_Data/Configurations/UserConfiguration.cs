using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyChat_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.last_seen).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.Status).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Birthday).IsRequired();
        }
    }
}
