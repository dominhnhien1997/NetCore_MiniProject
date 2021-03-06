﻿using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Holiday
{
    public class Deatils
    {
        public class Query : IRequest<TestHoliday>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, TestHoliday>
        {
            private readonly DataContext dataContext;
            public Handler(DataContext dataContext)
            {
                this.dataContext = dataContext;
            }
            public async Task<TestHoliday> Handle(Query request, CancellationToken cancellationToken)
            {
                return await dataContext.TestHolidays.FindAsync(request.Id);
            }
        }
    }
}
