using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactListUseCase.Models;

namespace ContactListUseCase.ViewModels
{
    public class ContactsViewModel
    {
        public List<Contact> listOfContacts { get; set; }
        
    }
}