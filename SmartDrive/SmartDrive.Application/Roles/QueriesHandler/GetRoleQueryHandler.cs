using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartDrive.Application.Exceptions;
using SmartDrive.Application.Roles.Models;
using SmartDrive.Application.Roles.Queries;
using SmartDrive.Domain.Entities;
using SmartDrive.Persistence.DataContext;

namespace Smart.Application.Roles.QueriesHandler
{ 
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, RoleViewModel>
    {
        private readonly SmartDriveDbContext _context;

        public GetRoleQueryHandler(SmartDriveDbContext context)
        {
            _context = context;
        }
        public async Task<RoleViewModel> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Roles.Where(x => x.RoleId == request.Id).Include(r => r.RoleDetails).AsNoTracking().SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new NotFoundException(nameof(Role), request.Id);
            }
            var vm = new RoleViewModel
            {
                Id = entity.RoleId,
                Name = entity.Name,
                Description = entity.Description,
                RoleDetails = entity.RoleDetails
                        .Where(x => x.Status == SmartDrive.Domain.Enumerations.DataStatus.Active)
                        .Select(x => new RoleDetailViewModel { Id = x.RoleDetailId, ModuleName = x.ModuleName, Permissions = x.Permissions }).ToList()
            };

            return vm;
        }
    }
}
