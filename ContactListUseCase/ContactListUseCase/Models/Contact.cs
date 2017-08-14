using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactListUseCase.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HomePhoneNumber { get; set; }
        public string BusinessPhoneNumber { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
    }
}