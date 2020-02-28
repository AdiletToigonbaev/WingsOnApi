using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WingsOn.Api.Models
{
    public class PersonViewModel
    {
        public string Name { get; set; }

        public DateTime DateBirth { get; set; }

        public GenderType Gender { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
    }
}