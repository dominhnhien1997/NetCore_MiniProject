using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Activitíe;
using Application.Activitie;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivityController : BaseController
    {
       [HttpPost]
       public async Task<ActionResult<Unit>> Create([FromBody]Create.Command command)
       {
            return await Mediator.Send(command);
       }

        //[HttpGet]
        //public async Task<ActionResult<List<Student>>> Get(CancellationToken ct)
        //{
        //    return await Mediator.Send(new List.Query());
        //}
    }
}