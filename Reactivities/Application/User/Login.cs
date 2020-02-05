using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Interface;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

using Persistence;

namespace Application.User
{
    public class Login
    {
        public class Query : IRequest<User>
        {
            public string Email { get; set; }

            public string Password { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public class Hanlder : IRequestHandler<Query, User>
        {
            private readonly UserManager<AppUser> userManger;
            private readonly SignInManager<AppUser> siginManger;
            private readonly IJwtGenerator jwt;

            public Hanlder(UserManager<AppUser> userManger, SignInManager<AppUser> siginManger, IJwtGenerator jwt)
            {
                this.siginManger = siginManger;
                this.userManger = userManger;
                this.jwt = jwt;
            }

            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                // xu ly logic login o day
                var userInfo = await userManger.FindByEmailAsync(request.Email);
                if (userInfo == null)
                {
                    throw new Exception("Email does not exist");
                }
                var result = await siginManger.CheckPasswordSignInAsync(userInfo, request.Password, false);
                if (result.Succeeded)
                {
                    //gen token o day 
                    return new User
                    {
                        DisplayName = userInfo.DisplayName,
                        Token = jwt.CreateToken(userInfo),
                        Username = userInfo.UserName,
                        Image = "http://baoventd.org/fileman/Uploads/Images/2019-01/mai-phuong-thuy-thua-nhan-day-la-nguoi-dan-ong-khien-co-me-met-nhat-1.jpg"
                    };
                }
                throw new Exception("Wrong password");
            }
        }
    }
}