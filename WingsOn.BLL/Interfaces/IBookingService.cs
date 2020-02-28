using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WingsOn.BLL.DTOs;
using WingsOn.Domain;

namespace WingsOn.BLL.Interfaces
{
    public interface IBookingService : IService<BookingDTO>
    {
        Task <Booking> BookAsync (IEnumerable<PersonDTO> passengers, string flightNumber);
    }
}
