
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using WPF_App.Mvvm.Models;
using WPF_App.Services;

namespace WPF_App.Mvvm.VievModels;

public partial class MainViewModel : ObservableObject
{ 

    [ObservableProperty]
    private ObservableObject currentViewModel;

    [ObservableProperty]
    private ObservableCollection<ContactModel> contactlist;

    [ObservableProperty]
    private string displayName;

    [ObservableProperty]
    private ContactModel selectedContact;

    [ObservableProperty]
    private string email;

    [RelayCommand]
    private void GoToAddContact()
    {
        CurrentViewModel = new AddContactViewModel();
    }

    [RelayCommand]
    private void GoToSpecificContact()
    {
        if (SelectedContact != null)
        {
            CurrentViewModel = new ContactsViewModel(SelectedContact);
        }
        else
        {
            CurrentViewModel = new ContactsViewModel();
        }
    }

    [RelayCommand]
    private void GoToEditContact(object sender)
    {
        var contact = sender as ContactModel;

        if (contact != null)
        {
            SelectedContact = contact;
            CurrentViewModel = new EditContactViewModel(contact);
        }
        else
        {
            CurrentViewModel = new EditContactViewModel();
        }



    }

    public MainViewModel()
    {
        CurrentViewModel = new ContactsViewModel();
        PopulateContactList();
    }

    public void PopulateContactList()
    {
        Contactlist = ListHandler.GetAllContacts();
    }
}
