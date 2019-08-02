using BookHome.Core.Entity;
using BookHome.Infrastracture.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookHome.WebApi.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [Authorize]
        [HttpGet]
        [Route("GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            return userService.GetAllUser().ToList();
        }
        [Authorize]
        [HttpPost]
        [Route("InsertUser")]
        public User InsertUser(User user)
        {
            return userService.Insert(user);
        }
    }
}
