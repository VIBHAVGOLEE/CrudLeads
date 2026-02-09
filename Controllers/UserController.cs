using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using CrudLeads.Application.DTOs;
using CrudLeads.Application.Interfaces;

namespace CrudLeads.Controllers
{
    [Authorize]
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<UserResponseDto>))]
        public IHttpActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet]
        [Route("{id:long}")]
        [ResponseType(typeof(UserResponseDto))]
        public IHttpActionResult GetById(long id)
        {
            var user = _userService.GetById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(UserResponseDto))]
        public IHttpActionResult Create([FromBody] UserCreateDto dto)
        {
            if (dto == null)
                return BadRequest("Request body is required.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = _userService.Create(dto);
            if (created == null)
                return Content(HttpStatusCode.Conflict, "UserName already exists or RoleId is invalid.");
            return Content(HttpStatusCode.Created, created);
        }

        [HttpPut]
        [Route("{id:long}")]
        [ResponseType(typeof(UserResponseDto))]
        public IHttpActionResult Update(long id, [FromBody] UserUpdateDto dto)
        {
            if (dto == null)
                return BadRequest("Request body is required.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = _userService.Update(id, dto);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        [HttpDelete]
        [Route("{id:long}")]
        public IHttpActionResult Delete(long id)
        {
            var user = _userService.GetById(id);
            if (user == null)
                return NotFound();
            _userService.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
