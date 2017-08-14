using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactListUseCase.Models;
using ContactListUseCase.ViewModels;
using System.Xml.Linq;
using System.Diagnostics;
using System.Xml.Serialization;
using System.IO;

namespace ContactListUseCase.Controllers
{
    public class ContactsController : Controller
    {

        public ActionResult ContactList()
        {

            List<Contact> contactList = GetListOfContacts();

            int numberOfContacts = contactList.Count;
            int numOfPages = (numberOfContacts % 10 == 0) ? numberOfContacts / 10 : (numberOfContacts / 10) + 1;

            //always initially take the first 10 ounce sorted in aphbetical order by first anme
            ContactListViewModel viewmodel = new ContactListViewModel { contacts = contactList.OrderBy(x => x.FirstName).Take(10).ToList() ,numberOfPages = numOfPages};
            

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult _ContactList(int PageNumber)
        {

            List<Contact> contactList = GetListOfContacts();
            
            //Return only the appropriate 10 contacts for the provided pageNumber
            int numberOfContacts = contactList.Count;
            int numOfPages = (numberOfContacts % 10 == 0) ? numberOfContacts / 10 : (numberOfContacts / 10) + 1;
            int contactsToSkip = 10 * (PageNumber - 1);
            ContactListViewModel viewmodel = new ContactListViewModel { contacts = contactList.OrderBy(x => x.FirstName).Skip(contactsToSkip).Take(10).ToList(), numberOfPages = numOfPages };

            return PartialView(viewmodel);
        }

        /// <summary>
        /// Get Contacts acts as a database call. It gets all of the contacts via an xml file.
        /// This would be a database call in larger applications.
        /// </summary>
        /// <returns></returns>
        public List<Contact> GetListOfContacts()
        {
            XElement xelement = XElement.Load(Server.MapPath("contacts.xml"));
            IEnumerable<XElement> contacts = xelement.Elements();
            int index = 0;
            List<Contact> contactList = contacts.Select(x => new Contact
            {
                Id = index++,
                FirstName = x.Element("firstname").Value,
                LastName = x.Element("lastname").Value,
                Email = x.Element("email").Value,
                HomePhoneNumber = x.Element("homephonenumber").Value,
                BusinessPhoneNumber = x.Element("businessphonenumber").Value,
                Address = x.Element("address").Value,
                Notes = x.Element("Notes").Value,
            }).ToList();

            return contactList;
        }

        [HttpPost]
        public ActionResult _ContactInfo(int id)
        {

            List<Contact> contactList = GetListOfContacts();          
            Contact selectedContact = contactList.Where(x => x.Id == id).Select(x => x).First();

            return PartialView(selectedContact);
        }

      

      

        [Route("contacts/{firstname}/{lastname}")]
        public ActionResult ByName(string firstname, string lastname)
        {

            return Content(firstname + "-" + lastname);
        }
    }
}