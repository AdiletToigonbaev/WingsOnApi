using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using WingsOn.BLL.Interfaces;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.Api.Controllers
{
    public class FlightsController : ApiController
    {

        private readonly IFlightService _service;

        public FlightsController(IFlightService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetPassengersByFlight (string number = "PZ696")
        {
            try
            {
                var result = await _service.GetPassengersByFlightAsync(number);
                return Ok(result);
            }
            catch (Exception e)
            {

                return Content(HttpStatusCode.NotFound, e.Message);
            }            
           
        }

    }
}