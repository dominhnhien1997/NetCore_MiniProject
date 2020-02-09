using Application.Errors;
using Application.Interface;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activitie
{
    public class Attend
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext context;
            private readonly IUserAccessor userAccessor;
            public Handler(DataContext dataContext, IUserAccessor userAccessor)
            {
                context = dataContext;
                this.userAccessor = userAccessor;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var userName = userAccessor.GetCurrentUserName();
                var user = await context.Users.SingleOrDefaultAsync(x => x.UserName == userName);
                var activi = await context.Activities.SingleOrDefaultAsync(x => x.Id == request.Id);
                var attend = await context.UserActivitys.SingleOrDefaultAsync(x => x.ActivityId == activi.Id && x.AppUserId == user.Id);
                if (attend != null)
                {
                    throw new RestException(System.Net.HttpStatusCode.BadRequest, new { attend = "activie da ton toi" });
                }
                if (activi == null)
                    throw new RestException(System.Net.HttpStatusCode.NotFound, new { activi = "Not Found Activi" });

                var useractivity = new UserActivity
                {
                    Activities = activi,
                    AppUser = user,
                    IsHost = false,
                    DateJoined = DateTime.Now
                };
                context.UserActivitys.Add(useractivity);
                var check = await context.SaveChangesAsync() > 0;

                if (check)
                    return Unit.Value;
                throw new Exception("Problem Dont save changeing");
            }
        }
    }
}
