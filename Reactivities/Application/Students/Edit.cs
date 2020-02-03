using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Students
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Address { get; set; }

            public DateTime? Birthday { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext context;
            public Handler(DataContext dataContext)
            {
                context = dataContext;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var student = await context.Students.FindAsync(request.Id);
                if (student == null)
                    throw new Exception("Not found student");
                student.FirstName = request.FirstName ?? student.FirstName;
                student.LastName = request.LastName ?? student.LastName;
                student.Address = request.Address ?? student.Address;
                student.Birthday = request.Birthday ?? student.Birthday;
                var success = await context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;
                throw new Exception("cannot update Student");
            }
        }
    }
}
