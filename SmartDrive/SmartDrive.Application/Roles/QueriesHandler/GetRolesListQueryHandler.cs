using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartDrive.Application.Roles.Models;
using SmartDrive.Application.Roles.Queries;
using SmartDrive.Domain.Enumerations;
using SmartDrive.Persistence.DataContext;

namespace SmartDrive.Application.Roles.QueriesHandler
{
    public class GetRolesListQueryHandler:IRequestHandler<GetRolesListQuery,RolesListViewModel>
    {
        private readonly SmartDriveDbContext _context;

        public GetRolesListQueryHandler(SmartDriveDbContext context)
        {
            _context = context;            
        }

        public async Task<RolesListViewModel> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            var vm = new RolesListViewModel
            {
                Roles = await _context.Roles.Where(r => r.Status == DataStatus.Active).Select(r =>
                        new RoleViewModel
                        {
                            Id = r.RoleId,
                            Name = r.Name,
                            Description = r.Description                         
                        }).ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
