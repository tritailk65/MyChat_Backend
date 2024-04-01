using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyChat_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChat_Data.Extensions
{
    public static class SeedingData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<Contact>().HasData(
            new Contact
            {
                contact_id = 1,
                contact_phone = "0797169613",
                UserId = adminId
            });
            modelBuilder.Entity<Contact>().HasData(
            new Contact
            {
                contact_id = 2,
                contact_phone = "0765184992",
                UserId = adminId
            });
            modelBuilder.Entity<Contact>().HasData(
            new Contact
            {
                contact_id = 3,
                contact_phone = "0364748018",
                UserId = adminId
            });

            modelBuilder.Entity<Chat>().HasData(
            new Chat
            {
                Chatid = 1,
                Content = "Xin Chao",
                created_at = DateTime.Now,
                Participants = 5,
                Title = "Hackathon",
            });
            modelBuilder.Entity<Chat>().HasData(
            new Chat
            {
                Chatid = 2,
                Content = "Xin Chao",
                created_at = DateTime.Now,
                Participants = 5,
                Title = "Web2",
            });
            modelBuilder.Entity<Chat>().HasData(
            new Chat
            {
                Chatid = 3,
                Content = "Xin Chao",
                created_at = DateTime.Now,
                Participants = 5,
                Title = "Android 2",
            });

            modelBuilder.Entity<Messenger>().HasData(
              new Messenger
              {
                  MessengerId = 1,
                  ChatId = 1,
                  Constamps = DateTime.ParseExact("24/02/2002", "dd/mm/yyyy", null),
                  Content = "Hello",
                  status = true
              });


            modelBuilder.Entity<UserRole>().HasData(new UserRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abc123@"),
                SecurityStamp = string.Empty,
                FirstName = "admin",
                LastName = "admin",
                Birthday = new DateTime(2002, 01, 01),
                PhoneNumber="0765184992",
                last_seen=DateTime.Now,
                Status=true,
                Username_Display="admin"
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}
