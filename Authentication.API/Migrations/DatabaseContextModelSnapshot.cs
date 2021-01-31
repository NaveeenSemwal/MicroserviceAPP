﻿// <auto-generated />
using System;
using AuthenticationService.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AuthenticationService.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("AuthenticationService.Database.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            Description = "Administrator",
                            Name = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            Description = "Employee",
                            Name = "Employee"
                        },
                        new
                        {
                            RoleId = 3,
                            Description = "User",
                            Name = "User"
                        });
                });

            modelBuilder.Entity("AuthenticationService.Database.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Address = "New Delhi",
                            ContactNo = "978776654",
                            CreatedDate = new DateTime(2021, 1, 31, 17, 11, 46, 602, DateTimeKind.Local).AddTicks(2920),
                            Name = "Administrator",
                            Password = "123",
                            Username = "admin"
                        },
                        new
                        {
                            UserId = 2,
                            Address = "New Delhi",
                            ContactNo = "978776654",
                            CreatedDate = new DateTime(2021, 1, 31, 17, 11, 46, 602, DateTimeKind.Local).AddTicks(3014),
                            Name = "Employee",
                            Password = "123",
                            Username = "emp"
                        },
                        new
                        {
                            UserId = 3,
                            Address = "New Delhi",
                            ContactNo = "978776654",
                            CreatedDate = new DateTime(2021, 1, 31, 17, 11, 46, 602, DateTimeKind.Local).AddTicks(3023),
                            Name = "User",
                            Password = "123",
                            Username = "user"
                        });
                });

            modelBuilder.Entity("AuthenticationService.Database.UserRoles", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("AuthenticationService.Database.UserRoles", b =>
                {
                    b.HasOne("AuthenticationService.Database.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuthenticationService.Database.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AuthenticationService.Database.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("AuthenticationService.Database.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}