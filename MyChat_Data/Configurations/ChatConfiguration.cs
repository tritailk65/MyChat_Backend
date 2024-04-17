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
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.ToTable("Chat");
            builder.HasKey(x => x.Chatid);
            builder.Property(x => x.Chatid).UseIdentityColumn();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Content).IsRequired().HasMaxLength(255);
            builder.Property(x => x.created_at).IsRequired().HasMaxLength(255);
            builder.HasOne(x => x.User).WithMany(x => x.Chats).HasForeignKey(x => x.UserId);
        }
    }
}
