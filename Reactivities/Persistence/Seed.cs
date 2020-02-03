using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManger)
        {
            if (!context.Users.Any())
            {
                IList<AppUser> users = new List<AppUser>()
                {
                    new AppUser
                    {
                        DisplayName ="Do minh nhien",
                        UserName="NhienDm",
                        Email="nhiendominh@gmail.com"
                    } ,
                    new AppUser
                    {
                        DisplayName ="ngo hai linh",
                        UserName="linhnh",
                        Email="linhnh@gmail.com"
                    },
                     new AppUser
                    {
                        DisplayName ="nguyen mai linh",
                        UserName="linhnm",
                        Email="linhnm@gmail.com"
                    }
                };
                foreach (var user in users)
                {
                    await userManger.CreateAsync(user, "Pa$$w0rd");
                }
            }

            if (!context.Students.Any())
            {
                IList<Student> students = new List<Student>()
                {
                    new Student
                    {
                        FirstName="Nhien",
                        LastName="do minh",
                        Address="la khe ha dong",
                    },
                    new Student
                    {
                        FirstName="linh",
                        LastName="pham my",
                        Address="la khe ha dong",
                    },
                    new Student
                    {
                        FirstName="ngan",
                        LastName="nguyen kim",
                        Address="la khe ha dong",
                    },
                    new Student
                    {
                        FirstName="huy",
                        LastName="pham",
                        Address="la khe ha dong",
                    },
                    new Student
                    {
                        FirstName="nguyet",
                        LastName="nguyen minh",
                        Address="la khe ha dong",
                    },
                    new Student
                    {
                        FirstName="tri",
                        LastName="nguyen duy",
                        Address="la khe ha dong",
                    },
                };
                context.Students.AddRange(students);
                context.SaveChanges();
            }
        }
    }
}
