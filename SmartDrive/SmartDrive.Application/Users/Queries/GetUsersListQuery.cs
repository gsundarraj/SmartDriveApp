﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SmartDrive.Application.Users.Models;

namespace SmartDrive.Application.Users.Queries
{
    public class GetUsersListQuery : IRequest <UsersListViewModel>
    {
    }
}
