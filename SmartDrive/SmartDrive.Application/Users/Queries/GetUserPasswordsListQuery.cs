using MediatR;
using SmartDrive.Application.Users.Models;

namespace SmartDrive.Application.Users.Queries
{
    public class GetUserPasswordsListQuery : IRequest<UserPasswordsListViewModel>
    {
        public int UserId { get; set; }
    }
}
