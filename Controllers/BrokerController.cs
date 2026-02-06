using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using CrudLeads.Application.DTOs;
using CrudLeads.Application.Interfaces;

namespace CrudLeads.Controllers
{
    [RoutePrefix("api/brokers")]
    public class BrokerController : ApiController
    {
        private readonly IBrokerService _brokerService;

        public BrokerController(IBrokerService brokerService)
        {
            _brokerService = brokerService;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<BrokerResponseDto>))]
        public IHttpActionResult GetAll()
        {
            var brokers = _brokerService.GetAll();
            return Ok(brokers);
        }

        [HttpGet]
        [Route("{id:long}")]
        [ResponseType(typeof(BrokerResponseDto))]
        public IHttpActionResult GetById(long id)
        {
            var broker = _brokerService.GetById(id);
            if (broker == null)
                return NotFound();
            return Ok(broker);
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(BrokerResponseDto))]
        public IHttpActionResult Create([FromBody] BrokerCreateDto dto)
        {
            if (dto == null)
                return BadRequest("Request body is required.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = _brokerService.Create(dto);
            return Content(HttpStatusCode.Created, created);
        }

        [HttpPut]
        [Route("{id:long}")]
        [ResponseType(typeof(BrokerResponseDto))]
        public IHttpActionResult Update(long id, [FromBody] BrokerUpdateDto dto)
        {
            if (dto == null)
                return BadRequest("Request body is required.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = _brokerService.Update(id, dto);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        [HttpDelete]
        [Route("{id:long}")]
        public IHttpActionResult Delete(long id)
        {
            var broker = _brokerService.GetById(id);
            if (broker == null)
                return NotFound();
            _brokerService.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
