using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Holiday;
using Application.Interface;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class HolidayController : BaseController
    {
        private readonly IUserAccessor accessor;
        public HolidayController(IUserAccessor accessor)
        {
            this.accessor = accessor;
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<TestHoliday>>> Get(CancellationToken ct)
        {
            var userName = accessor.GetCurrentUserName();
            var test = await Mediator.Send(new List.Query());
            if (test != null)
                return Ok(test);
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var check = await Mediator.Send(command);
            if (check != null)
                return Ok();
            return NotFound("dont insert data");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TestHoliday>> Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            var test = await Mediator.Send(new Deatils.Query { Id = id });
            return Ok(test);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Update(Guid id, [FromBody]Edit.Command command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await Mediator.Send(new Delete.Command { Id = id });
        }
    }
}