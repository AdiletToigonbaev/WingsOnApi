using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using WingsOn.BLL.DTOs;
using WingsOn.BLL.Interfaces;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.Api.Controllers
{
    public class BookingsController : ApiController
    {

        private readonly IBookingService _service;

        private readonly IMapper _mapper;

        public BookingsController(IBookingService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Book (IEnumerable <PersonDTO> passengers, string flightNumber)
        {
            try
            {
                var result = await _service.BookAsync(passengers, flightNumber);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }        
        }

    }
}
