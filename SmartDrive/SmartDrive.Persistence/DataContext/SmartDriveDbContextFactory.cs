using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SmartDrive.Persistence.Infrastructure;

namespace SmartDrive.Persistence.DataContext
{
    public class SmartDriveDbContextFactory : DesignTimeDbContextFactoryBase<SmartDriveDbContext>
    {
        protected override SmartDriveDbContext CreateNewInstance(DbContextOptions<SmartDriveDbContext> options)
        {
            return new SmartDriveDbContext(options);
        }
    }
}
