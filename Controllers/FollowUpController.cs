using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using CrudLeads.Application.DTOs;
using CrudLeads.Application.Interfaces;

namespace CrudLeads.Controllers
{
    [RoutePrefix("api/followups")]
    public class FollowUpController : ApiController
    {
        private readonly IFollowUpService _followUpService;

        public FollowUpController(IFollowUpService followUpService)
        {
            _followUpService = followUpService;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<FollowUpResponseDto>))]
        public IHttpActionResult GetAll()
        {
            var items = _followUpService.GetAll();
            return Ok(items);
        }

        [HttpGet]
        [Route("broker/{brokerId:long}")]
        [ResponseType(typeof(IEnumerable<FollowUpResponseDto>))]
        public IHttpActionResult GetByBrokerId(long brokerId)
        {
            var items = _followUpService.GetByBrokerId(brokerId);
            return Ok(items);
        }

        [HttpGet]
        [Route("lead/{leadId:long}")]
        [ResponseType(typeof(IEnumerable<FollowUpResponseDto>))]
        public IHttpActionResult GetByLeadId(long leadId)
        {
            var items = _followUpService.GetByLeadId(leadId);
            return Ok(items);
        }

        [HttpGet]
        [Route("{id:long}")]
        [ResponseType(typeof(FollowUpResponseDto))]
        public IHttpActionResult GetById(long id)
        {
            var item = _followUpService.GetById(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(FollowUpResponseDto))]
        public IHttpActionResult Create([FromBody] FollowUpCreateDto dto)
        {
            if (dto == null)
                return BadRequest("Request body is required.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = _followUpService.Create(dto);
            return Content(HttpStatusCode.Created, created);
        }

        [HttpPut]
        [Route("{id:long}")]
        [ResponseType(typeof(FollowUpResponseDto))]
        public IHttpActionResult Update(long id, [FromBody] FollowUpUpdateDto dto)
        {
            if (dto == null)
                return BadRequest("Request body is required.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = _followUpService.Update(id, dto);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        [HttpDelete]
        [Route("{id:long}")]
        public IHttpActionResult Delete(long id)
        {
            var existing = _followUpService.GetById(id);
            if (existing == null)
                return NotFound();
            _followUpService.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}

