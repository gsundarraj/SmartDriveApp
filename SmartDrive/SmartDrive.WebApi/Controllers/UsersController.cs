using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartDrive.Application.Users.Models;
using SmartDrive.Application.Users.Queries;

namespace SmartDrive.WebApi.Controllers
{
    [Route("api/users")]
    public class UsersController : BaseController
    {
        //GET api/users       
        [HttpGet]
        public async Task<ActionResult<UsersListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetUsersListQuery()));
        }
    }
}