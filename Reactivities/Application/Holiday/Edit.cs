using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Holiday
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }

            public string Address1 { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext data;
            public Handler(DataContext data)
            {
                this.data = data;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var testHoliday = await data.TestHolidays.FindAsync(request.Id);
                if (testHoliday == null)
                {
                    throw new Exception("not a holiday");
                }
                testHoliday.Name = request.Name ?? testHoliday.Name;
                testHoliday.Address = request.Address ?? testHoliday.Address;
                testHoliday.Address1 = request.Address1 ?? testHoliday.Address1;
                var success = await data.SaveChangesAsync() > 0;
                if (success) return Unit.Value;
                throw new Exception("cannot update Student");
            }
        }
    }
}
