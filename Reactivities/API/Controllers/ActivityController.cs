using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Activitíe;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {

        private readonly IMediator mediator;
        public ActivityController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        //[HttpGet]
        //public async Task<List<Student>> List()
        //{
        //    return await mediator.Send(new List.Query());
        //}
    }
}