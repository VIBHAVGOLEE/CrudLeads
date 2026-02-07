using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using CrudLeads.Application.DTOs;
using CrudLeads.Application.Interfaces;

namespace CrudLeads.Controllers
{
    [RoutePrefix("api/statuses")]
    public class StatusController : ApiController
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<StatusResponseDto>))]
        public IHttpActionResult GetAll()
        {
            var items = _statusService.GetAll();
            return Ok(items);
        }

        [HttpGet]
        [Route("category/{category}")]
        [ResponseType(typeof(IEnumerable<StatusResponseDto>))]
        public IHttpActionResult GetByCategory(string category)
        {
            var items = _statusService.GetByCategory(category);
            return Ok(items);
        }

        [HttpGet]
        [Route("{id:long}")]
        [ResponseType(typeof(StatusResponseDto))]
        public IHttpActionResult GetById(long id)
        {
            var item = _statusService.GetById(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
    }
}

