using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using CrudLeads.Application.DTOs;
using CrudLeads.Application.Interfaces;

namespace CrudLeads.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<CustomerResponseDto>))]
        public IHttpActionResult GetAll()
        {
            var items = _customerService.GetAll();
            return Ok(items);
        }

        [HttpGet]
        [Route("broker/{brokerId:long}")]
        [ResponseType(typeof(IEnumerable<CustomerResponseDto>))]
        public IHttpActionResult GetByBrokerId(long brokerId)
        {
            var items = _customerService.GetByBrokerId(brokerId);
            return Ok(items);
        }

        [HttpGet]
        [Route("lead/{leadId:long}")]
        [ResponseType(typeof(CustomerResponseDto))]
        public IHttpActionResult GetByLeadId(long leadId)
        {
            var item = _customerService.GetByLeadId(leadId);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpGet]
        [Route("{id:long}")]
        [ResponseType(typeof(CustomerResponseDto))]
        public IHttpActionResult GetById(long id)
        {
            var item = _customerService.GetById(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
    }
}

