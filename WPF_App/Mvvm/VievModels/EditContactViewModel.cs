using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.IO;
using WPF_App.Mvvm.Models;
using WPF_App.Services;

namespace WPF_App.Mvvm.VievModels
{
    internal partial class EditContactViewModel : ObservableObject
    {
        private ContactModel oldContact;

        [ObservableProperty]
        private string pageName = "Edit Contact";

        [ObservableProperty]
        private string firstName = string.Empty;

        [ObservableProperty]
        private string lastName = string.Empty;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string phone = string.Empty;

        [ObservableProperty]
        private string street = string.Empty;

        [ObservableProperty]
        private string zipCode = string.Empty;

        [ObservableProperty]
        private string city = string.Empty;

        public EditContactViewModel(ContactModel selectedContact)
        {
            oldContact = new ContactModel
            {
                Id= selectedContact.Id,
                FirstName = selectedContact.FirstName,
                LastName = selectedContact.LastName,
                Email = selectedContact.Email,
                Phone = selectedContact.Phone,
                Street = selectedContact.Street,
                ZipCode = selectedContact.ZipCode,
                City = selectedContact.City
            };

            FirstName = selectedContact.FirstName;
            LastName = selectedContact.LastName;
            Email = selectedContact.Email;
            Phone = selectedContact.Phone;
            Street = selectedContact.Street;
            ZipCode = selectedContact.ZipCode;
            City = selectedContact.City;
        }

        public EditContactViewModel()
        {

        }

        [RelayCommand]
        private void SaveUpdatedContact()
        {
            ContactModel updatedContact = new ContactModel
            {
                Id = oldContact.Id,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Phone = Phone,
                Street = Street,
                ZipCode = ZipCode,
                City = City,
            };
            ListHandler.ContactReplace(updatedContact);

            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            Street = string.Empty;
            ZipCode = string.Empty;
            City = string.Empty;
        }
    }
}
