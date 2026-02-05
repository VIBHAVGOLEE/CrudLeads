using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CrudLeads.Controllers
{
    /// <summary>
    /// Redirects site root to Swagger UI.
    /// </summary>
    [RoutePrefix("")]
    public class DefaultController : ApiController
    {
        /// <summary>
        /// Redirect root to Swagger UI.
        /// </summary>
        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            var swaggerPath = VirtualPathUtility.ToAbsolute("~/swagger");
            var baseUri = Request.RequestUri.GetLeftPart(System.UriPartial.Authority);
            var response = Request.CreateResponse(HttpStatusCode.Redirect);
            response.Headers.Location = new System.Uri(baseUri + swaggerPath);
            return response;
        }
    }
}
