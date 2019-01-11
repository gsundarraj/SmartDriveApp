using System;
using System.Collections.Generic;
using System.Linq;
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
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, Unit>
    {
        private readonly SmartDriveDbContext _context;

        public DeleteRoleCommandHandler(SmartDriveDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Roles
                     .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Role), request.Id);
            }

            //var hasUsers= _context.Users.Any(u => u.RoleId == entity.RoleId);
            //if (hasUsers)
            //{
            //    throw new DeleteFailureException(nameof(Plan), request.Id, "There are existing Users associated with this Role.");
            //}

            entity.Status = Domain.Enumerations.DataStatus.InActive;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
