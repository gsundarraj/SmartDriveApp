using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartDrive.Application.Exceptions;
using SmartDrive.Application.Users.Commands;
using SmartDrive.Domain.Entities;
using SmartDrive.Persistence.DataContext;

namespace SmartDrive.Application.Users.CommandsHandler
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly SmartDriveDbContext _context;

        public UpdateUserCommandHandler(SmartDriveDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.Include(u => u.Address)
                 .SingleOrDefaultAsync(c => c.UserId == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            //Check Username and Email is Unique 
            var users = _context.Users;
            var exception = new ValidationException();
            if (users.Any(x => x.UserName == request.UserName && x.UserId != entity.UserId))
            {
                exception.Failures.Add("UserName", new string[] { "UserName Already Exist" });
                throw exception;

            }
            else if (users.Any(x => x.Email == request.Email && x.UserId != entity.UserId))
            {
                exception.Failures.Add("Email", new string[] { "Email Already Exist" });
                throw exception;

            }

            //Update User
            entity.OrganizationId = request.OrganizationId;
            entity.Name = request.Name;
            entity.Email = request.Email;
            entity.Mobile = request.Mobile;           
            entity.UserName = request.UserName;
            entity.AddressId = request.AddressId;
            entity.IsActived = request.IsActived;
            entity.IsPrimary = request.IsPrimary;

            if (entity.Address != null )
            {
                entity.Address.Address1 = request.Address.Address1;
                entity.Address.Address2 = request.Address.Address2;
                entity.Address.City = request.Address.City;
                entity.Address.State = request.Address.State;
                entity.Address.Country = request.Address.Country;
                entity.Address.Pincode = request.Address.Pincode;
                entity.Address.MapData = request.Address.MapData;
            }
            else if (entity.AddressId == null && request.Address != null)
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
          
            _context.Users.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
