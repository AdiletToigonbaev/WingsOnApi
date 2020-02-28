using System;
using System.Collections.Generic;
using System.Text;
using WingsOn.Domain;

namespace WingsOn.BLL.DTOs
{
    public class PersonDTO : DTOObject
    {
        public string Name { get; set; }

        public DateTime DateBirth { get; set; }

        public GenderType Gender { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
    }
}
