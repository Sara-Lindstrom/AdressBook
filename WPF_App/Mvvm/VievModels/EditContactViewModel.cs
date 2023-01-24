using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPF_App.Mvvm.Models;
using WPF_App.Services;

namespace WPF_App.Mvvm.VievModels
{
    internal partial class EditContactViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageName = "Edit Contact";

        [ObservableProperty]
        private string firstname = string.Empty;

        [ObservableProperty]
        private string lastname = string.Empty;

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
            Firstname = selectedContact.FirstName;
            Lastname = selectedContact.LastName;
            Email = selectedContact.Email;
            Phone = selectedContact.Phone;
            Street = selectedContact.Street;
            ZipCode = selectedContact.ZipCode;
            City = selectedContact.City;
        }

        public EditContactViewModel()
        {

        }
    }
}
