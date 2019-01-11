using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SmartDrive.Application.Exceptions;
using SmartDrive.Application.Users.Commands;
using SmartDrive.Domain.Entities;
using SmartDrive.Persistence.DataContext;

namespace SmartDrive.Application.Users.CommandsHandler
{ 
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly SmartDriveDbContext _context;

        public DeleteUserCommandHandler(SmartDriveDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            //var hasPlanDetails = _context.PlanDetails.Any(o => o.PlanId == entity.PlanId);
            //if (hasPlanDetails)
            //{
            //    throw new DeleteFailureException(nameof(Plan), request.Id, "There are existing PlanDetails associated with this Plan.");
            //}
            //_context.Plans.Remove(entity);

            entity.Status = Domain.Enumerations.DataStatus.InActive;

            _context.Users.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
