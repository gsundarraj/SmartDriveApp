using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SmartDrive.Domain.Entities;
using SmartDrive.Persistence.DataContext;
using SmartDrive.Application.Exceptions;
using SmartDrive.Domain.Enumerations;
using SmartDrive.Application.Users.Commands;

namespace SmartDrive.Application.Users.CommandsHandler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly SmartDriveDbContext _context;

        public CreateUserCommandHandler(SmartDriveDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //Check Username and Email is Unique 
            var users = _context.Users;
            var exception = new ValidationException();
            if (users.Any(x=>x.UserName == request.UserName))
            {               
                exception.Failures.Add("UserName", new string[] { "UserName Already Exist" });
                throw exception;

            }
            else if (users.Any(x=>x.Email == request.Email))
            {
                exception.Failures.Add("Email", new string[] { "Email Already Exist" });
                throw exception;

            }

            //Create User
            var entity = new User
            {                      
                OrganizationId = request.OrganizationId,
                Name = request.Name,
                Email = request.Email,
                Mobile = request.Mobile,
                UserName = request.UserName,
                IsActived = request.IsActived,
                IsPrimary = request.IsPrimary,
                Status = Domain.Enumerations.DataStatus.Active,                

            };

            if (request.Address != null)
            {
                Address addressEntity = new Address
                {
                    Address1 = request.Address.Address1,
                    Address2 = request.Address.Address2,
                    City = request.Address.City,
                    State = request.Address.State,
                    Country = request.Address.Country,
                    Pincode = request.Address.Pincode,
                    MapData = request.Address.MapData
                };
                _context.Addresses.Add(addressEntity);
                await _context.SaveChangesAsync(cancellationToken);
                entity.AddressId = addressEntity.AddressId;
            }

            //if(request.UserOrganizations != null)
            //{
            //    entity.UserOrganizations = request.UserOrganizations.Select(x => new UserOrganization { OrganizationId = x.OrganizationId, RoleId = x.RoleId, IsDefault = x.IsDefault, Status = DataStatus.Active }).ToList();
            //}

            _context.Users.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
