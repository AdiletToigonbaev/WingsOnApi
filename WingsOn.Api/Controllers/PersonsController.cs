using AutoMapper;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using WingsOn.Api.Models;
using WingsOn.BLL.DTOs;
using WingsOn.BLL.Interfaces;
using WingsOn.BLL.Mapping;

namespace WingsOn.Api.Controllers
{
    public class PersonsController : ApiController
    {
        private readonly IPersonService _service;
        private readonly IMapper _mapper;
      
        public PersonsController(IPersonService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        
        [HttpGet]      
        public async Task<IHttpActionResult> Get(int id)        
        {
            try
            {
                var person = await _service.GetAsync(id);
               
                return Ok(person);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }            
        }

        [HttpGet]        
        public async Task<IHttpActionResult> GetByGender(string gender)
        {
            try
            {
                var persons = await _service.GetByGenderAsync(gender);
                return Ok(persons);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }       
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateAddress([FromBody] UpdateAddressModel person)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.NotFound, "Not a valid model.");
            }
            try
            {
                var updatedPerson = await _service.UpdateAddressAsync(_mapper.Map<UpdateAddressDTO>(person));
                return Ok(_mapper.Map<PersonViewModel>(updatedPerson));
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            }       
        }

    }
}