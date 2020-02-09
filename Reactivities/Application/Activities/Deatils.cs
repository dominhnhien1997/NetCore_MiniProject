using Application.Errors;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activitie
{
    public class Deatils
    {
        public class Query : IRequest<ActivitiesDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ActivitiesDto>
        {
            private readonly DataContext dataContext;
            private readonly IMapper mapper;
            public Handler(DataContext dataContext, IMapper mapper)
            {
                this.dataContext = dataContext;
                this.mapper = mapper;
            }
            public async Task<ActivitiesDto> Handle(Query request, CancellationToken cancellationToken)
            {
                //doan code nay su dung eager loading dung de loading tung phan cua data
                //var test = await dataContext.Activities
                //             .Include(x => x.UserActivities)
                //             .ThenInclude(x => x.AppUser)
                //             .SingleOrDefaultAsync(x => x.Id == request.Id);

                // con doan duoi day dc dung khi da cai dat lazay loading
                var test = await dataContext.Activities.FindAsync(request.Id);
                if (test == null)
                    throw new RestException(System.Net.HttpStatusCode.NotFound, new { test = "NotFoud" });
                var activiToreturn = mapper.Map<Activities, ActivitiesDto>(test);
                return activiToreturn;
            }
        }
    }
}
