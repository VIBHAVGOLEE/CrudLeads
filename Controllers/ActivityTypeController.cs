using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using CrudLeads.Application.DTOs;
using CrudLeads.Application.Interfaces;

namespace CrudLeads.Controllers
{
    [RoutePrefix("api/activitytypes")]
    public class ActivityTypeController : ApiController
    {
        private readonly IActivityTypeService _activityTypeService;

        public ActivityTypeController(IActivityTypeService activityTypeService)
        {
            _activityTypeService = activityTypeService;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<ActivityTypeResponseDto>))]
        public IHttpActionResult GetAll()
        {
            var activityTypes = _activityTypeService.GetAll();
            return Ok(activityTypes);
        }

        [HttpGet]
        [Route("{id:long}")]
        [ResponseType(typeof(ActivityTypeResponseDto))]
        public IHttpActionResult GetById(long id)
        {
            var activityType = _activityTypeService.GetById(id);
            if (activityType == null)
                return NotFound();
            return Ok(activityType);
        }
    }
}
