using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartDrive.Application.Exceptions;
using SmartDrive.Application.Roles.Commands;
using SmartDrive.Domain.Entities;
using SmartDrive.Persistence.DataContext;

namespace SmartDrive.Application.Roles.CommandsHandler
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, Unit>
    {
        private readonly SmartDriveDbContext _context;

        public UpdateRoleCommandHandler(SmartDriveDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {

            var entity = await _context.Roles
                  .SingleOrDefaultAsync(c => c.RoleId == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Role), request.Id);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;
            await UpsertRoleDetails(request.RoleDetails, entity.RoleId, cancellationToken);

            _context.Roles.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }

        private async Task<bool> UpsertRoleDetails (IList<UpdateRoleDetail> roleDetails, int roleId, CancellationToken cancellationToken)
        {
            try
            {
                foreach (var item in roleDetails)
                {
                    if (item.Id == 0)
                    {
                        var entity = new RoleDetail
                        {
                            RoleId = roleId,
                            ModuleName = item.ModuleName,
                            Permissions = item.Permissions,
                            
                        };
                        _context.RoleDetails.Add(entity);
                        await _context.SaveChangesAsync(cancellationToken);
                    }
                    else
                    {
                        var entity = await _context.RoleDetails.SingleOrDefaultAsync(c => c.RoleDetailId == item.Id, cancellationToken);
                        if (entity != null)
                        {
                            entity.ModuleName = item.ModuleName;
                            entity.Permissions = item.Permissions;
                            _context.RoleDetails.Update(entity);
                            await _context.SaveChangesAsync(cancellationToken);
                        }

                    }

                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}
