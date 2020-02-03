using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Students
{
    public class Deatils
    {
        public class Query : IRequest<Student>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Student>
        {
            private readonly DataContext context;
            public Handler(DataContext context)
            {
                this.context = context;
            }
            public async Task<Student> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.Students.FindAsync(request.Id);
            }
        }
    }
}
