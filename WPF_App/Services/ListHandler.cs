using Newtonsoft.Json;
using System.Collections.ObjectModel;
using WPF_App.Models;

namespace WPF_App.Services;

internal class ListHandler
{
    private ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();
    private FileService file = new FileService(); 

    public ListHandler()
    {
        GetAllContacts();
    }


    public void ContactAdd(Contact contact)
    {
        contacts.Add(contact);
        file.Save(JsonConvert.SerializeObject(contacts, Formatting.Indented));
    }


    public ObservableCollection<Contact> GetAllContacts()
    {
        try
        {
            var items = JsonConvert.DeserializeObject<ObservableCollection<Contact>>(file.Read());

            if (items != null)
            {
                contacts = items;
            }
        }
        catch { }
        return contacts;
    }
}
