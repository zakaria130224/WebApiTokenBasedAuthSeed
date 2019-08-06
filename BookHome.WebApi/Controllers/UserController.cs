using BookHome.Core.Entity;
using BookHome.Infrastracture.Services;
using System;
using System.Linq;
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

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var result = userService.GetAllUser().ToList();

                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return Ok(new { success = false, errorMessage = ex.Message });
            }
        }

        [HttpPost]
        [Route("Insert")]
        public IHttpActionResult Insert(User user)
        {
            try
            {
                var result = userService.Insert(user);

                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return Ok(new { success = false, errorMessage = ex.Message });
            }
        }

        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update(User user)
        {
            try
            {
                var result = userService.Update(user);

                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return Ok(new { success = false, errorMessage = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(int Id)
        {
            try
            {
                userService.Delete(Id);

                return Ok(new { success = true, data = true });
            }
            catch (Exception ex)
            {
                return Ok(new { success = false, errorMessage = ex.Message });
            }
        }
    }
}
