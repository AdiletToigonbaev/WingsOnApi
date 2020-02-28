using System;
using System.Collections.Generic;
using System.Text;

namespace WingsOn.BLL.DTOs
{
    public class BookingDTO : DTOObject
    {
        public string Number { get; set; }

        public FlightDTO Flight { get; set; }

        public PersonDTO Customer { get; set; }

        public IEnumerable<PersonDTO> Passengers { get; set; }

        public DateTime DateBooking { get; set; }
    }
}
