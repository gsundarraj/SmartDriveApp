using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SmartDrive.Application.Roles.Commands;
using SmartDrive.Domain.Entities;
using SmartDrive.Domain.Enumerations;
using SmartDrive.Persistence.DataContext;

namespace SmartDrive.Application.Roles.CommandsHandler
{
    public class CreateRoleCommandHandler:IRequestHandler<CreateRoleCommand, Unit>
    {
        private readonly SmartDriveDbContext _context;

        public CreateRoleCommandHandler(SmartDriveDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = new Role
            {
                Name = request.Name,
                Description = request.Description,
                Status = DataStatus.Active,
                RoleDetails = request.RoleDetails.Select(x => new RoleDetail { ModuleName = x.ModuleName, Permissions = x.Permissions, Status = DataStatus.Active }).ToList(),
            };

            _context.Roles.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);



            return Unit.Value;
        }

       
    }
}
