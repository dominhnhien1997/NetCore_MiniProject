using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

        [HttpPost("{id}/attend")]
        public async Task<ActionResult<Unit>> Attend(Guid id)
        {
            return await Mediator.Send(new Attend.Command { Id = id });
        }

        [HttpDelete("{id}/attend")]
        public async Task<ActionResult<Unit>> RemoveAttend(Guid id)
        {
            return await Mediator.Send(new RemoveAttend.Command { Id = id });
        }

        [HttpGet]
        public async Task<ActionResult<List<ActivitiesDto>>> Get(CancellationToken ct)
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivitiesDto>> Deatails(Guid id)
        {
            return await Mediator.Send(new Deatils.Query { Id = id });
        }


    }
}