using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Application.Interface;
using Microsoft.AspNetCore.Http;

namespace Infratructure.Serurity
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor httpContext;
        public UserAccessor(IHttpContextAccessor httpContext)
        {
            this.httpContext = httpContext;
        }
        public string GetCurrentUserName()
        {
            var userName = httpContext.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return userName;
        }
    }
}
