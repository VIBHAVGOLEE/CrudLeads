using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using CrudLeads.Application.DTOs;
using CrudLeads.Application.Interfaces;

namespace CrudLeads.Controllers
{
    [RoutePrefix("api/leadSources")]
    public class LeadSourceController : ApiController
    {
        private readonly ILeadSourceService _leadSourceService;

        public LeadSourceController(ILeadSourceService leadSourceService)
        {
            _leadSourceService = leadSourceService;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<LeadSourceResponseDto>))]
        public IHttpActionResult GetAll()
        {
            var items = _leadSourceService.GetAll();
            return Ok(items);
        }

        [HttpGet]
        [Route("{id:long}")]
        [ResponseType(typeof(LeadSourceResponseDto))]
        public IHttpActionResult GetById(long id)
        {
            var item = _leadSourceService.GetById(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
    }
}

