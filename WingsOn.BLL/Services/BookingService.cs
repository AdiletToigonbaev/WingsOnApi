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
    public class BookingService : IBookingService
    {
        BookingRepository _repository;
        FlightRepository _flightRepository;
        private readonly IMapper _mapper;
        public BookingService(BookingRepository repository, FlightRepository flightRepository, IMapper mapper)
        {
            _repository = repository;
            _flightRepository = flightRepository;
            _mapper = mapper;
        }

        public async Task <Booking> BookAsync(IEnumerable<PersonDTO> passengers, string flightNumber)
        {
            if (!_flightRepository.GetAll().Any(p => p.Number == flightNumber))
            {
                throw new Exception("Invalid flight number");
            }

            var flight = await Task.Run(()=> _flightRepository.GetAll().FirstOrDefault(p => p.Number == flightNumber));
            var lastId = _repository.GetAll().OrderBy(p => p.Id).LastOrDefault().Id;
            var booking = new Booking()
            {
                Number = "somePNR",
                Id = ++lastId,
                DateBooking = DateTime.Today,
                Flight = flight,
                Passengers = _mapper.Map<IEnumerable<Person>>(passengers),
                Customer = _mapper.Map<IEnumerable<Person>>(passengers).FirstOrDefault()
            };

            _repository.Save(booking);

            return booking;
        }

        public IEnumerable<BookingDTO> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
