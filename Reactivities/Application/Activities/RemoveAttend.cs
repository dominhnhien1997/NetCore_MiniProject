using Application.Errors;
using Application.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activitie
{
    public class RemoveAttend
    {

        public class Command : IRequest
        {

            public Guid Id { get; set; }
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
                var user = await dataContext.Users.SingleOrDefaultAsync(x => x.UserName == userName);
                var activi = await dataContext.Activities.SingleOrDefaultAsync(x => x.Id == request.Id);
                var attend = await dataContext.UserActivitys.SingleOrDefaultAsync(x => x.ActivityId == activi.Id && x.AppUserId == user.Id);
                if (activi == null)
                    throw new RestException(System.Net.HttpStatusCode.NotFound, new { activi = "Not Found Activi" });
                dataContext.UserActivitys.Remove(attend);
                var check = await dataContext.SaveChangesAsync() > 0;
                if (check)
                    return Unit.Value;
                throw new Exception("Problem Dont remove changeing");
            }
        }
    }
}
