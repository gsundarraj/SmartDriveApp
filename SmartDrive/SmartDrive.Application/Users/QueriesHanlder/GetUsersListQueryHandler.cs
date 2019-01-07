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
using SmartDrive.Domain.Enumerations;
using SmartDrive.Persistence.DataContext;

namespace SmartDrive.Application.Users.QueriesHanlder
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, UsersListViewModel>
    {
        private readonly SmartDriveDbContext _context;

        public GetUsersListQueryHandler(SmartDriveDbContext context)
        {
            _context = context;           
        }
        public async Task<UsersListViewModel> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var vm = new UsersListViewModel
            {
                Users = await _context.Users.Select(u =>
                        new UserLookupModel
                        {
                            Id = u.UserId,
                            Name = u.Name,
                            Email = u.Email,
                            Mobile = u.Mobile
                        }).ToListAsync(cancellationToken)
            };

            return vm;
        }
    }
}
