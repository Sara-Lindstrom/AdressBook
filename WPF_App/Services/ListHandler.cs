using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Linq;
using WPF_App.Mvvm.Models;

namespace WPF_App.Services;

public static class ListHandler
{
    private static ObservableCollection<ContactModel> contacts;
    private static FileService file;

    static ListHandler()
    {
        GetAllContacts();
        file = new FileService();
        contacts = file.Read();
    }


    public static void ContactAdd(ContactModel contact)
    {
        contacts.Add(contact);
        file.Save(JsonConvert.SerializeObject(contacts, Formatting.Indented));
    }

    public static void ContactRemove(ContactModel contact)
    {
        contacts.Remove(contact);
        file.Save(JsonConvert.SerializeObject(contacts, Formatting.Indented));

    }

    public static ObservableCollection<ContactModel> GetAllContacts()
    {
        return contacts;
    }

    public static void ContactReplace(ContactModel updatedContact)
    {

        var oldContact = contacts.FirstOrDefault(c=>c.Id== updatedContact.Id);

        if (oldContact.Id == updatedContact.Id)
        {
            contacts.Remove(oldContact);
            contacts.Add(updatedContact);
            file.Save(JsonConvert.SerializeObject(contacts, Formatting.Indented));
        }
    }
}
