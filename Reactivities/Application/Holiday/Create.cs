using MediatR;
using Persistence;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Application.Holiday
{
    public class Create
    {
        public class Command : IRequest
        {

            public string Name { get; set; }

            public string Address { get; set; }

            public string DisplayName { get; set; }

            public string Address1 { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage("Khong duoc de trong truong ten null");
                RuleFor(x => x.Address).NotEmpty().WithMessage("Khong duoc de trong truong dia chi null");
            }
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

                var test = new TestHoliday
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Address = request.Address,
                    Address1 = request.Address1,
                    DisplayName = request.DisplayName,
                };
                context.TestHolidays.Add(test);
                var check = await context.SaveChangesAsync() > 0;
                if (check)
                    return Unit.Value;
                throw new Exception("dont save");
            }
        }

    }
}
