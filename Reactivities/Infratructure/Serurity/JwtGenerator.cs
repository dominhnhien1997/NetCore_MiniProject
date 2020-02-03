using Application.Interface;
using Domain;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infratructure.Serurity
{
    public class JwtGenerator : IJwtGenerator
    {
        public string CreateToken(AppUser appUser)
        {
            var claim = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,appUser.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super secret key"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDes = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claim),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDes);
            var result = tokenHandler.WriteToken(token);
            return result;
        }
    }
}
