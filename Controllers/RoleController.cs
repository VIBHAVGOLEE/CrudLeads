using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using CrudLeads.Application.DTOs;
using CrudLeads.Application.Interfaces;

namespace CrudLeads.Controllers
{
    [Authorize]
    [RoutePrefix("api/roles")]
    public class RoleController : ApiController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<RoleResponseDto>))]
        public IHttpActionResult GetAll()
        {
            var roles = _roleService.GetAll();
            return Ok(roles);
        }

        [HttpGet]
        [Route("{id:long}")]
        [ResponseType(typeof(RoleResponseDto))]
        public IHttpActionResult GetById(long id)
        {
            var role = _roleService.GetById(id);
            if (role == null)
                return NotFound();
            return Ok(role);
        }
    }
}
