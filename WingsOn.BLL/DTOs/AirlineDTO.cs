using System;
using System.Collections.Generic;
using System.Text;
using WingsOn.Domain;

namespace WingsOn.BLL.DTOs
{
    public class AirlineDTO : DTOObject
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
