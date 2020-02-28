using System;
using System.Collections.Generic;
using System.Text;

namespace WingsOn.BLL.DTOs
{
    public class FlightDTO : DTOObject
    {

        public string Number { get; set; }

        public AirlineDTO Carrier { get; set; }

        public AirportDTO DepartureAirport { get; set; }

        public DateTime DepartureDate { get; set; }

        public AirportDTO ArrivalAirport { get; set; }

        public DateTime ArrivalDate { get; set; }

        public decimal Price { get; set; }
    }
}
