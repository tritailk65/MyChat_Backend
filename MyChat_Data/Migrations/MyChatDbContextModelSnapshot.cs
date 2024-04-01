﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyChat_Data.EF;

#nullable disable

namespace MyChat_Data.Migrations
{
    [DbContext(typeof(MyChatDbContext))]
    partial class MyChatDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("AppUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                            RoleId = new Guid("8d04dce2-969a-435d-bba4-df3f325983dc")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserTokens", (string)null);
                });

            modelBuilder.Entity("MyChat_Data.Entities.Chat", b =>
                {
                    b.Property<int>("Chatid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Chatid"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Participants")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("created_at")
                        .HasMaxLength(255)
                        .HasColumnType("datetime2");

                    b.HasKey("Chatid");

                    b.HasIndex("UserId");

                    b.ToTable("Chat", (string)null);

                    b.HasData(
                        new
                        {
                            Chatid = 1,
                            Content = "Xin Chao",
                            Participants = 5,
                            Title = "Hackathon",
                            created_at = new DateTime(2024, 4, 1, 7, 57, 0, 701, DateTimeKind.Local).AddTicks(9066)
                        },
                        new
                        {
                            Chatid = 2,
                            Content = "Xin Chao",
                            Participants = 5,
                            Title = "Web2",
                            created_at = new DateTime(2024, 4, 1, 7, 57, 0, 701, DateTimeKind.Local).AddTicks(9088)
                        },
                        new
                        {
                            Chatid = 3,
                            Content = "Xin Chao",
                            Participants = 5,
                            Title = "Android 2",
                            created_at = new DateTime(2024, 4, 1, 7, 57, 0, 701, DateTimeKind.Local).AddTicks(9096)
                        });
                });

            modelBuilder.Entity("MyChat_Data.Entities.Contact", b =>
                {
                    b.Property<int>("contact_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("contact_id"), 1L, 1);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("contact_phone")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("contact_id");

                    b.HasIndex("UserId");

                    b.ToTable("Contact", (string)null);

                    b.HasData(
                        new
                        {
                            contact_id = 1,
                            UserId = new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                            contact_phone = "0797169613"
                        },
                        new
                        {
                            contact_id = 2,
                            UserId = new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                            contact_phone = "0765184992"
                        },
                        new
                        {
                            contact_id = 3,
                            UserId = new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                            contact_phone = "0364748018"
                        });
                });

            modelBuilder.Entity("MyChat_Data.Entities.Messenger", b =>
                {
                    b.Property<int>("MessengerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessengerId"), 1L, 1);

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Constamps")
                        .HasMaxLength(200)
                        .HasColumnType("datetime2");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("status")
                        .HasMaxLength(200)
                        .HasColumnType("bit");

                    b.HasKey("MessengerId");

                    b.HasIndex("ChatId");

                    b.ToTable("Messenger", (string)null);

                    b.HasData(
                        new
                        {
                            MessengerId = 1,
                            ChatId = 1,
                            Constamps = new DateTime(2002, 1, 24, 0, 2, 0, 0, DateTimeKind.Unspecified),
                            Content = "Hello",
                            status = true
                        });
                });

            modelBuilder.Entity("MyChat_Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasMaxLength(255)
                        .HasColumnType("bit");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username_Display")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("last_seen")
                        .HasMaxLength(255)
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                            AccessFailedCount = 0,
                            Birthday = new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "923f6c42-ec67-4dd0-8583-64f14f53fbd0",
                            Email = "admin@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "admin",
                            LastName = "admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@gmail.com",
                            NormalizedUserName = "admin",
                            PasswordHash = "AQAAAAEAACcQAAAAELUHgysTrO2H2vGMdfnvtYfmbzBDvJbGlAW5ZcqzrRu2VHtxG63bzFMkOvUd1niT1w==",
                            PhoneNumber = "0765184992",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            Status = true,
                            TwoFactorEnabled = false,
                            UserName = "admin",
                            Username_Display = "admin",
                            last_seen = new DateTime(2024, 4, 1, 7, 57, 0, 703, DateTimeKind.Local).AddTicks(6452)
                        });
                });

            modelBuilder.Entity("MyChat_Data.Entities.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserRole", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                            ConcurrencyStamp = "90e9c98f-1906-4ce9-9504-c1e0913b3a1b",
                            Description = "Administrator role",
                            Name = "admin",
                            NormalizedName = "admin"
                        });
                });

            modelBuilder.Entity("MyChat_Data.Entities.Chat", b =>
                {
                    b.HasOne("MyChat_Data.Entities.User", null)
                        .WithMany("Participants")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MyChat_Data.Entities.Contact", b =>
                {
                    b.HasOne("MyChat_Data.Entities.User", "User")
                        .WithMany("UserId")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyChat_Data.Entities.Messenger", b =>
                {
                    b.HasOne("MyChat_Data.Entities.Chat", "Chat")
                        .WithMany("Messengers")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("MyChat_Data.Entities.Chat", b =>
                {
                    b.Navigation("Messengers");
                });

            modelBuilder.Entity("MyChat_Data.Entities.User", b =>
                {
                    b.Navigation("Participants");

                    b.Navigation("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
