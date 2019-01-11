using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartDrive.Application.Exceptions;
using SmartDrive.Application.Users.Models;
using SmartDrive.Application.Users.Queries;
using SmartDrive.Domain.Entities;
using SmartDrive.Domain.Enumerations;
using SmartDrive.Persistence.DataContext;

namespace SmartDrive.Application.Users.QueriesHanlder
{ 
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly SmartDriveDbContext _context;

        public GetUserQueryHandler(SmartDriveDbContext context)
        {
            _context = context;
        }
        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.Include(u => u.Address)
                 .FirstOrDefaultAsync(c => c.UserId == request.Id && c.Status == DataStatus.Active, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            var vm = new UserViewModel
            {
                Id = entity.UserId,
                AddressId = entity.AddressId,
                Name = entity.Name,
                Email = entity.Email,
                Mobile = entity.Mobile,
                UserName = entity.UserName,
                IsActived = entity.IsActived,
                IsPrimary = entity.IsPrimary,               
            };
            if (entity.Address != null)
            {
                vm.Address = new Users.Models.AddressViewModel()
                {
                    Address1 = entity.Address.Address1,
                    Address2 = entity.Address.Address2,
                    City = entity.Address.City,
                    State = entity.Address.State,
                    Country = entity.Address.Country,
                    Pincode = entity.Address.Pincode,
                    MapData = entity.Address.MapData
                };
            }
            return vm;
        }
    }
}
