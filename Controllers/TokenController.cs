using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpGet]
        public List<AspNetUserToken> Get(string userId)
        {
            var context = new EFCoreWebApiContext();
            List<AspNetUserToken> userTokens;

            if (userId != null)
            {
                userTokens = context.AspNetUserTokens.Where(row => row.UserId == userId).ToList();
            }
            else
            {
                userTokens = context.AspNetUserTokens.ToList();
            }

            return userTokens;
        }
    }
}