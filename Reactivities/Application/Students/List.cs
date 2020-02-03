using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Students
{
    public class List
    {
        public class Query : IRequest<List<Student>> { }

        public class Handler : IRequestHandler<Query, List<Student>>
        {
            private readonly DataContext dataContext;
            private readonly ILogger<List> logger;
            public Handler(DataContext context, ILogger<List> logger)
            {
                dataContext = context;
                this.logger = logger;
            }
            public async Task<List<Student>> Handle(Query request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();
                return await dataContext.Students.ToListAsync(cancellationToken);
            }
        }
    }
}
