using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using CrudLeads.Application.DTOs;
using CrudLeads.Application.Interfaces;

namespace CrudLeads.Controllers
{
    [Authorize]
    [RoutePrefix("api/leads")]
    public class LeadController : ApiController
    {
        private readonly ILeadService _leadService;

        public LeadController(ILeadService leadService)
        {
            _leadService = leadService;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<LeadResponseDto>))]
        public IHttpActionResult GetAll()
        {
            var leads = _leadService.GetAll();
            return Ok(leads);
        }

        [HttpGet]
        [Route("broker/{brokerId:long}")]
        [ResponseType(typeof(IEnumerable<LeadResponseDto>))]
        public IHttpActionResult GetByBrokerId(long brokerId)
        {
            var leads = _leadService.GetByBrokerId(brokerId);
            return Ok(leads);
        }

        [HttpGet]
        [Route("{id:long}")]
        [ResponseType(typeof(LeadResponseDto))]
        public IHttpActionResult GetById(long id)
        {
            var lead = _leadService.GetById(id);
            if (lead == null)
                return NotFound();
            return Ok(lead);
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(LeadResponseDto))]
        public IHttpActionResult Create([FromBody] LeadCreateDto dto)
        {
            if (dto == null)
                return BadRequest("Request body is required.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = _leadService.Create(dto);
            return Content(HttpStatusCode.Created, created);
        }

        [HttpPut]
        [Route("{id:long}")]
        [ResponseType(typeof(LeadResponseDto))]
        public IHttpActionResult Update(long id, [FromBody] LeadUpdateDto dto)
        {
            if (dto == null)
                return BadRequest("Request body is required.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = _leadService.Update(id, dto);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        [HttpDelete]
        [Route("{id:long}")]
        public IHttpActionResult Delete(long id)
        {
            var lead = _leadService.GetById(id);
            if (lead == null)
                return NotFound();
            _leadService.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}

