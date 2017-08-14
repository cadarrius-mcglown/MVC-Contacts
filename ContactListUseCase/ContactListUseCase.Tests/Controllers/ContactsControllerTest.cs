using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using ContactListUseCase;
using ContactListUseCase.Controllers;

namespace ContactListUseCase.Tests.Controllers
{
    [TestClass]
    public class ContactsControllerTest
    {
        [TestMethod]
        public void ContactList()
        {
            //Arrange 
            ContactsController controller = new ContactsController();

            //act
            ActionResult result = controller.ContactList() as ActionResult;


            //assert
            Assert.IsNotNull(result);

        }
    }
}
