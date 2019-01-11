﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartDrive.Persistence.DataContext;

namespace SmartDrive.Persistence.Migrations
{
    [DbContext(typeof(SmartDriveDbContext))]
    [Migration("20190111135525_OrganizationAdded")]
    partial class OrganizationAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SmartDrive.Domain.Entities.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("MapData");

                    b.Property<string>("Pincode");

                    b.Property<string>("State");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("SmartDrive.Domain.Entities.Organization", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<string>("Code");

                    b.Property<string>("Description");

                    b.Property<bool>("IsFavourite");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("OrganizationId");

                    b.HasIndex("AddressId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("SmartDrive.Domain.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("SmartDrive.Domain.Entities.RoleDetail", b =>
                {
                    b.Property<int>("RoleDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ModuleName");

                    b.Property<string>("Permissions");

                    b.Property<int>("RoleId");

                    b.Property<int>("Status");

                    b.HasKey("RoleDetailId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleDetails");
                });

            modelBuilder.Entity("SmartDrive.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<string>("Email");

                    b.Property<bool>("IsActived");

                    b.Property<bool>("IsFavourite");

                    b.Property<bool>("IsPrimary");

                    b.Property<bool>("IsSuperAdmin");

                    b.Property<string>("Mobile");

                    b.Property<string>("Name");

                    b.Property<int>("OrganizationId");

                    b.Property<int>("Status");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.HasIndex("AddressId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SmartDrive.Domain.Entities.UserPassword", b =>
                {
                    b.Property<int>("UserPasswordId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("Hint");

                    b.Property<bool>("IsCurrent");

                    b.Property<bool>("IsLocked");

                    b.Property<string>("Password");

                    b.Property<int>("RetryCount");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("UserId");

                    b.HasKey("UserPasswordId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPasswords");
                });

            modelBuilder.Entity("SmartDrive.Domain.Entities.Organization", b =>
                {
                    b.HasOne("SmartDrive.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("SmartDrive.Domain.Entities.RoleDetail", b =>
                {
                    b.HasOne("SmartDrive.Domain.Entities.Role", "Role")
                        .WithMany("RoleDetails")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartDrive.Domain.Entities.User", b =>
                {
                    b.HasOne("SmartDrive.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("SmartDrive.Domain.Entities.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartDrive.Domain.Entities.UserPassword", b =>
                {
                    b.HasOne("SmartDrive.Domain.Entities.User", "User")
                        .WithMany("Passwords")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}