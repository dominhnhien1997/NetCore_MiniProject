using Application.Interface;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User
{
    public class CurrentUser
    {
        public class Query : IRequest<User>
        {

        }

        public class Handler : IRequestHandler<Query, User>
        {
            private readonly UserManager<AppUser> userManger;

            private readonly IJwtGenerator jwtGenerator;
            private readonly IUserAccessor userAccessor;
            public Handler(UserManager<AppUser> userManger, IJwtGenerator jwtGenerator, IUserAccessor userAccessor)
            {
                this.userManger = userManger;
                this.jwtGenerator = jwtGenerator;
                this.userAccessor = userAccessor;
            }
            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                var userName = await userManger.FindByNameAsync(userAccessor.GetCurrentUserName());
                return new User
                {
                    DisplayName = userName.DisplayName,
                    Username = userName.UserName,
                    Token = jwtGenerator.CreateToken(userName),
                    Image = null
                };
            }
        }
    }
}
