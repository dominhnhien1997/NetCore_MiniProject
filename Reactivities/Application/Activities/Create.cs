using Application.Errors;
using Application.Interface;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activitie
{
    public class Create
    {
        public class Command : IRequest
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public string City { get; set; }
            public string Venue { get; set; }
        }

        public class CommandValidator :AbstractValidator<Command> 
        {
            public CommandValidator()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.Description).NotEmpty();
                RuleFor(x => x.Category).NotEmpty();
                RuleFor(x => x.City).NotEmpty();
                RuleFor(x => x.Venue).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext dataContext;
            private readonly IUserAccessor userAccessor;
            public Handler(DataContext dataContext, IUserAccessor userAccessor)
            {
                this.dataContext = dataContext;
                this.userAccessor = userAccessor;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var userName = userAccessor.GetCurrentUserName();
                var activity = new Activities
                {
                    Id = Guid.NewGuid(),
                    Title = request.Title,
                    Category = request.Category,
                    Date = DateTime.Now,
                    City = request.City,
                    Venue = request.Venue
                };
                dataContext.Activities.Add(activity);
                //add user to user activiti
                var user = await dataContext.Users.SingleOrDefaultAsync(x=>x.UserName ==userName);
                var userActivity = new UserActivity
                {
                    AppUser =user,
                    Activities = activity,
                    IsHost=true,
                    DateJoined= DateTime.Now
                };
                dataContext.UserActivitys.Add(userActivity);
                var check = await dataContext.SaveChangesAsync() > 0;
                if (check)
                    return Unit.Value;
                throw new Exception("dont create activiti");
            }
        }
    }
}
