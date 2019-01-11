using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SmartDrive.Application.Roles.Models;

namespace SmartDrive.Application.Roles.Queries
{
    public class GetRolesListQuery:IRequest<RolesListViewModel>
    {
    }
}
