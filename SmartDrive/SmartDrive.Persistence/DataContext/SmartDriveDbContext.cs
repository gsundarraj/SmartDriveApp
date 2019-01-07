using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SmartDrive.Domain.Entities;
using SmartDrive.Persistence.Extensions;

namespace SmartDrive.Persistence.DataContext
{
    public class SmartDriveDbContext : DbContext
    {
        public SmartDriveDbContext(DbContextOptions<SmartDriveDbContext> options) : base(options)
        {           

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();

        }

        public DbSet<User> Users { get; set; }
       
    }
}

