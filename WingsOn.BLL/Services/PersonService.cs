using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WingsOn.BLL.DTOs;
using WingsOn.BLL.Interfaces;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.BLL.Services
{
    public class PersonService : IPersonService
    {      
        private readonly PersonRepository _repository;
        private readonly IMapper _mapper;
        public PersonService(PersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IEnumerable<PersonDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<PersonDTO>>(_repository.GetAll());
        }

        public async Task<PersonDTO> GetAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception(string.Format("Person ID cannot be zero or negative"));
            }

            var result = _mapper.Map<PersonDTO>(await Task.Run(()=>_repository.Get(id)));
            if (result == null)
            {
                throw new Exception(string.Format("Person with ID {0} not found", id));
            }
           
            return result;
        }

        public async Task<IEnumerable<PersonDTO>> GetByGenderAsync(string gender)
        {
            if (string.IsNullOrEmpty(gender))
            {
                throw new Exception(string.Format("Gender name is empty"));
            }

            if (!Enum.GetNames(typeof(GenderType)).Any(x => x.ToLower().Equals(gender.ToLower())))
            {
                throw new Exception(string.Format("Invalid gender name"));
            }

            var result =  _mapper.Map<IEnumerable<PersonDTO>>(await Task.Run(()=>_repository.GetAll().Where(p => p.Gender.ToString().ToLower() == gender.ToLower())));
            return result;
        }

        public async Task<PersonDTO> UpdateAddressAsync(UpdateAddressDTO dto)
        {
            var existingPerson = await Task.Run(() => _repository.Get(dto.PersonId));
            if (existingPerson != null)
            {
                existingPerson.Address = dto.Adress;
                _repository.Save(existingPerson);
                return _mapper.Map<PersonDTO>(existingPerson);
            }
            else
            {
                throw new Exception("No Person with ID = " + dto.PersonId);
            }
        }
      
    }
}
