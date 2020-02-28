using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WingsOn.BLL.DTOs;
using WingsOn.Domain;

namespace WingsOn.BLL.Interfaces
{
    public interface IFlightService : IService<FlightDTO>
    {
       Task <IEnumerable<PersonDTO>> GetPassengersByFlightAsync(string number);
    }
}
