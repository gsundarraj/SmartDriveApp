using MediatR;

namespace SmartDrive.Application.Roles.Commands
{
    public class DeleteRoleDetailCommand : IRequest
    {
        public int Id { get; set; }
    }
}
