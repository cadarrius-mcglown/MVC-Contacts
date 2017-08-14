using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactListUseCase.Models;

namespace ContactListUseCase.ViewModels
{
    public class ContactListViewModel
    {
        public List<Contact> contacts = new List<Contact>();
        public int numberOfPages = 1;
    }
}