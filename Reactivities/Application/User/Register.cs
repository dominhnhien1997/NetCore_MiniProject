using Application.Interface;
using Application.Validator;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Rest;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User
{
    public class Register
    {
        public class Command : IRequest<User>
        {
            public string DisplayName { get; set; }

            public string Username { get; set; }

            public string Email { get; set; }

            public string Password { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.DisplayName).NotEmpty();
                RuleFor(x => x.Username).NotEmpty();
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                RuleFor(x => x.Password).Password();
            }
        }

        public class Handler : IRequestHandler<Command, User>
        {
            private readonly DataContext context;
            private readonly UserManager<AppUser> manager;
            private readonly IJwtGenerator jwt;
            public Handler(DataContext context, UserManager<AppUser> manager, IJwtGenerator jwt)
            {
                this.context = context;
                this.manager = manager;
                this.jwt = jwt;

            }
            public async Task<User> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await context.Users.Where(x => x.Email == request.Email).AnyAsync())
                {
                    throw new RestException("Email alerady exits");
                }

                if (await context.Users.Where(x => x.UserName == request.Email).AnyAsync())
                {
                    throw new RestException("Username alerady exits");
                }
                var user = new AppUser
                {
                    DisplayName = request.DisplayName,
                    UserName = request.Username,
                    Email = request.Email
                };

                var result = await manager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    return new User
                    {
                        DisplayName = user.DisplayName,
                        Token = jwt.CreateToken(user),
                        Username = user.UserName,
                        Image = null
                    };
                }
                throw new Exception("Problem creating user");
            }
        }
    }
}
