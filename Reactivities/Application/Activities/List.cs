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
    public class List
    {
        public class Query : IRequest<List<ActivitiesDto>> { }

        public class Handler : IRequestHandler<Query, List<ActivitiesDto>>
        {
            private readonly DataContext dataContext;
            private readonly IMapper mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                dataContext = context;
                this.mapper = mapper;
            }
            public async Task<List<ActivitiesDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                // doan duoi day su dung eager loading
                //var activities = await dataContext.Activities
                //                       .Include(x => x.UserActivities)
                //                       .ThenInclude(x => x.AppUser)
                //                       .ToListAsync();

                //doan duoi day sy dung lazay loading
                var activities = await dataContext.Activities.ToListAsync();
                var result = mapper.Map<List<Activities>, List<ActivitiesDto>>(activities);
                return result;
            }
        }
    }
}
