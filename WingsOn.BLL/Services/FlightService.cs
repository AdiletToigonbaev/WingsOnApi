using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingsOn.BLL.DTOs;
using WingsOn.BLL.Interfaces;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.BLL.Services
{
    public class FlightService : IFlightService
    {

        private readonly IMapper _mapper;
        private readonly FlightRepository _repository;
        private readonly  BookingRepository _bookingRepository;
        public FlightService(FlightRepository repository, BookingRepository bookingRepository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _bookingRepository = bookingRepository;
        }
        public IEnumerable<FlightDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<FlightDTO>>(_repository.GetAll());
        }

        public async Task <IEnumerable<PersonDTO>> GetPassengersByFlightAsync(string number)
        {
            if (!_repository.GetAll().Any(f=>f.Number == number))
            {
                throw new Exception("Invalid flight number: " + number);
            }

            var passengers = await Task.Run(()=> _bookingRepository.GetAll().Where(p => p.Flight.Number == number).SelectMany(p => p.Passengers));           
            return _mapper.Map<IEnumerable<PersonDTO>>(passengers);
        }
    }
}
