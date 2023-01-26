using System.IO;
using System.Reflection.Emit;
using WPF_App.Mvvm.Models;
using WPF_App.Services;

namespace WPF_App.Test
{
    public class UnitTest
    {
        ContactModel contact;
        int contactListCount = ListHandler.GetAllContacts().Count;

        public UnitTest()
        {
            contact = new ContactModel();
        }

        [Fact]
        public void Should_Add_And_Remove_Contact_To_List()
        {
            int addedContactCount = contactListCount +1;


            ListHandler.ContactAdd(contact);

            Assert.Equal(addedContactCount, ListHandler.GetAllContacts().Count);


            ListHandler.ContactRemove(contact);

            Assert.Equal(contactListCount, ListHandler.GetAllContacts().Count);

        }
    }
}