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
	public class ContactConfiguration : IEntityTypeConfiguration<Contact>
	{
		public void Configure(EntityTypeBuilder<Contact> builder)
		{
			builder.ToTable("Contact");
			builder.HasKey(x => x.contact_id);
			builder.Property(x => x.contact_id).UseIdentityColumn();
            builder.Property(x => x.contact_phone).HasMaxLength(200).IsRequired();
            builder.HasOne(x => x.User).WithMany(x => x.UserId).HasForeignKey(x => x.UserId);
        }
	}
}
