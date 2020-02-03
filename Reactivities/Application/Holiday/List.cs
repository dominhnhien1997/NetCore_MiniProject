using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Holiday
{
    public class List
    {
        public class Query : IRequest<List<TestHoliday>> 
        { 
        
        
        
        }

        public class Handler : IRequestHandler<Query, List<TestHoliday>>
        {
            private readonly DataContext context;
            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<List<TestHoliday>> Handle(Query request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();
                return await context.TestHolidays.ToListAsync(cancellationToken);
            }
        }
    }
}
