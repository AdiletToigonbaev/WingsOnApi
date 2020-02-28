using System;
using System.Collections.Generic;
using System.Text;

namespace WingsOn.BLL.DTOs
{
    public class AirportDTO : DTOObject
    {
        public string Code { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
    }
}
