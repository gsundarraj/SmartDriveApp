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
using SmartDrive.Infrastructure.Services;
using SmartDrive.Persistence.DataContext;

namespace SmartDrive.Application.Users.CommandsHandler
{ 
    public class CreateUserPasswordCommandHandler : IRequestHandler<CreateUserPasswordCommand, Unit>
    {
        private readonly SmartDriveDbContext _context;

        public CreateUserPasswordCommandHandler(SmartDriveDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Include(p=>p.Passwords)
                   .SingleOrDefaultAsync(c => c.UserId == request.UserId, cancellationToken);

            if (user == null)
            {
                 throw new NotFoundException(nameof(User), request.UserId);              
            }
            if(user.Passwords.Count > 0)
            {
                foreach (var password in user.Passwords)
                {
                    password.IsCurrent = false;
                    _context.UserPasswords.Update(password);
                    await _context.SaveChangesAsync(cancellationToken);
                }

            }
            var entity = new UserPassword
            {
                UserId = request.UserId,
                Password = PasswordHandler.Encrypt(request.Password),
                Hint = request.Hint,
                StartDate = DateTime.Now,
                IsCurrent =true     
            };
            _context.UserPasswords.Add(entity);
             await _context.SaveChangesAsync(cancellationToken);

             return Unit.Value;
        }
    }
}
