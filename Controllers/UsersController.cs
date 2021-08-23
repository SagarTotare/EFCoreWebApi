using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public List<AspNetUser> Get(string name)
        {
            var context = new EFCoreWebApiContext();
            List<AspNetUser> userList;

            if (name != null)
            {
                userList = context.AspNetUsers.Where(row => row.FirstName == name).ToList();
            }
            else
            {
                userList = context.AspNetUsers.ToList();
            }

            return userList;
        }

        [HttpGet]
        [Route("get-one")]
        public AspNetUser GetOne(string id, string name)
        {
            var context = new EFCoreWebApiContext();

            var user = context.AspNetUsers.Where(user => user.FirstName == name)
                .FirstOrDefault();

            return user;
        }

        [HttpPost]
        public string Post(AspNetUser aspNetUser)
        {
            using (var context = new EFCoreWebApiContext())
            {
                DateTimeOffset now = (DateTimeOffset)DateTime.UtcNow;

                var user = new AspNetUser()
                {
                    Id = now.ToString("yyyyMMddHHmmssfff"),
                    UserName = aspNetUser.UserName,
                    NormalizedUserName = aspNetUser.NormalizedUserName,
                    Email = aspNetUser.Email,
                    NormalizedEmail = aspNetUser.NormalizedEmail,
                    EmailConfirmed = aspNetUser.EmailConfirmed,
                    PasswordHash = aspNetUser.PasswordHash,
                    SecurityStamp = aspNetUser.SecurityStamp,
                    ConcurrencyStamp = aspNetUser.ConcurrencyStamp,
                    PhoneNumber = aspNetUser.PhoneNumber,
                    PhoneNumberConfirmed = aspNetUser.PhoneNumberConfirmed,
                    TwoFactorEnabled = aspNetUser.TwoFactorEnabled,
                    LockoutEnd = aspNetUser.LockoutEnd,
                    LockoutEnabled = aspNetUser.LockoutEnabled,
                    AccessFailedCount = aspNetUser.AccessFailedCount,
                    FirstName = aspNetUser.FirstName,
                    LastName = aspNetUser.LastName
                };

                context.AspNetUsers.Add(user);
                context.SaveChanges();
            }
            return "User Added successfully...!";
        }

        [HttpPut("{id}")]
        public string Put(string id, AspNetUser aspNetUser)
        {

            using (var context = new EFCoreWebApiContext())
            {
                var user = context.AspNetUsers.Find(id);
                user.UserName = aspNetUser.UserName;
                user.NormalizedUserName = aspNetUser.NormalizedUserName;
                user.Email = aspNetUser.Email;
                user.NormalizedEmail = aspNetUser.NormalizedEmail;
                user.EmailConfirmed = aspNetUser.EmailConfirmed;
                user.PasswordHash = aspNetUser.PasswordHash;
                user.SecurityStamp = aspNetUser.SecurityStamp;
                user.ConcurrencyStamp = aspNetUser.ConcurrencyStamp;
                user.PhoneNumber = aspNetUser.PhoneNumber;
                user.PhoneNumberConfirmed = aspNetUser.PhoneNumberConfirmed;
                user.TwoFactorEnabled = aspNetUser.TwoFactorEnabled;
                user.LockoutEnd = aspNetUser.LockoutEnd;
                user.LockoutEnabled = aspNetUser.LockoutEnabled;
                user.AccessFailedCount = aspNetUser.AccessFailedCount;
                user.FirstName = aspNetUser.FirstName;
                user.LastName = aspNetUser.LastName;

                context.SaveChanges();
            }

            return "User updated Successfully..!";

        }

        [HttpDelete("{id}")]
        public string Delete(string id)
        {
            using (var context = new EFCoreWebApiContext())
            {
                var user = context.AspNetUsers.Find(id);
                context.AspNetUsers.Remove(user);
                context.SaveChanges();
            }

            return "User deleted successfully...!";
        }
    }
}