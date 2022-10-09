using Newtonsoft.Json.Serialization;
using PruebaTecnica.DAO;
using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PruebaTecnica.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PATCH, DELETE, OPTIONS")]
    [Route("api/users")]
    public class UsersController : ApiController
    {
        private UsersDAO dao = new UsersDAO();

        [HttpPost]
        public IHttpActionResult CreateUser([FromBody] UserRequest userDto)
        {
            if (ModelState.IsValid)
            {
                var userResponse = dao.CreateUser(userDto);

                if (userResponse != null && userResponse.IdUser > 0)
                    return Ok(userResponse);

                return InternalServerError();
            } 
            else
            {
                return BadRequest();
            }
        }

        [HttpPatch]
        [Route("api/users/{idUser}")]
        public IHttpActionResult UpdateUser(long idUser, [FromBody] UserRequest userDto)
        {
            if (ModelState.IsValid)
            {
                var userResponse = dao.UpdateUser(idUser, userDto);

                if (userResponse != null && userResponse.IdUser > 0)
                    return Ok(userResponse);

                return InternalServerError();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("api/users/{idUser}")]
        public IHttpActionResult DeleteUser(long idUser)
        {
            var userResponse = dao.DeleteUser(idUser);

            if (userResponse != null && userResponse.IdUser > 0)
                return Ok(userResponse);
            else if(userResponse != null)
                return Ok();

            return InternalServerError();
        }

        [HttpGet]
        [Route("api/users")]
        public IHttpActionResult GetUsers()
        {
            IEnumerable<UserResponse> users = dao.GetAllUsers();
            
            if (users != null)
                return Ok(users);
                
            return InternalServerError();
        }

        [HttpGet]
        [Route("api/users/{idUser}")]
        public IHttpActionResult GetUser(long idUser)
        {
            UserResponse userResponse = dao.GetUser(idUser);

            if (userResponse != null)
                return Ok(userResponse);
                
            return InternalServerError();
        }
    }
}
