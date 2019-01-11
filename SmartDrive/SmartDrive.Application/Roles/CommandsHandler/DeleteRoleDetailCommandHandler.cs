using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SmartDrive.Application.Exceptions;
using SmartDrive.Application.Roles.Commands;
using SmartDrive.Domain.Entities;
using SmartDrive.Persistence.DataContext;

namespace SmartDrive.Application.Roles.CommandsHandler
{
    public class DeleteRoleDetailCommandHandler : IRequestHandler<DeleteRoleDetailCommand, Unit>
    {
        private readonly SmartDriveDbContext _context;

        public DeleteRoleDetailCommandHandler(SmartDriveDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteRoleDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RoleDetails
                        .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(RoleDetail), request.Id);
            }

            entity.Status = Domain.Enumerations.DataStatus.InActive;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
