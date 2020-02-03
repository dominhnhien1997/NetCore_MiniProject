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
    public class Create
    {
        public class Command : IRequest
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Address { get; set; }

            public DateTime Birthday { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var student = new Student
                {
                    Id = Guid.NewGuid(),
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Address = request.Address,
                    Birthday = request.Birthday,
                };
                context.Students.Add(student);
                var check = await context.SaveChangesAsync() > 0;
                if (check)
                    return Unit.Value;
                throw new Exception("dont save");
            }
        }
    }
}
