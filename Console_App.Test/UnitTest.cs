using System.ComponentModel.Design;
using Console_App.Models;
using Console_App.Services;

namespace Console_App.Test
{
    public class UnitTest
    {
        private MenuService menuService;
        Contact contact;

        public UnitTest()
        {
            menuService= new MenuService();
            contact = new Contact();
        }

        [Fact]
        public void Test1()
        {
            int contactsCount = menuService.contacts.Count + 2;

            menuService.contacts.Add(contact);
            menuService.contacts.Add(contact);

            Assert.Equal(contactsCount, menuService.contacts.Count);
        }
    }
}