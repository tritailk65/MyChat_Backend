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
	public class MessengerConfiguration : IEntityTypeConfiguration<Messenger>
	{
		public void Configure(EntityTypeBuilder<Messenger> builder)
		{
			builder.ToTable("Messenger");
			builder.HasKey(x=>x.MessengerId);
			builder.Property(x => x.MessengerId).UseIdentityColumn();
			builder.Property(x => x.Content).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Constamps).HasMaxLength(200).IsRequired();
            builder.Property(x => x.status).HasMaxLength(200).IsRequired();
            builder.HasOne(x => x.Chat).WithMany(x => x.Messengers).HasForeignKey(x => x.ChatId);

		}
	}
}
