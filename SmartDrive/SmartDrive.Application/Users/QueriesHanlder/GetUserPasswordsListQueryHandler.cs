using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartDrive.Application.Users.Models;
using SmartDrive.Application.Users.Queries;
using SmartDrive.Persistence.DataContext;

namespace SmartDrive.Application.Users.QueriesHanlder
{
    public class GetUserPasswordsListQueryHandler : IRequestHandler<GetUserPasswordsListQuery, UserPasswordsListViewModel>
    {
        private readonly SmartDriveDbContext _context;

        public GetUserPasswordsListQueryHandler(SmartDriveDbContext context)
        {
            _context = context;          
        }
        public async Task<UserPasswordsListViewModel> Handle(GetUserPasswordsListQuery request, CancellationToken cancellationToken)
        {
            var vm = new UserPasswordsListViewModel
            {
                Passwords = await _context.UserPasswords.Where(u => u.UserId == request.UserId).Select(u =>
                        new UserPasswordViewModel
                        {
                            Id = u.UserPasswordId,
                            UserId = u.UserId,
                            Password = u.Password,
                            Hint = u.Hint,
                            RetryCount = u.RetryCount,
                            IsCurrent = u.IsCurrent,
                            StartDate = u.StartDate,
                            EndDate = u.EndDate,
                            IsLocked = u.IsLocked                          
                        }).ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
