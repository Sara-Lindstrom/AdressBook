
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPF_App.Mvvm.Models;
using WPF_App.Services;

namespace WPF_App.Mvvm.VievModels;

internal partial class AddContactViewModel : ObservableObject
{
    [ObservableProperty]
    private string pageTitle = "Add New Contact";

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

    [RelayCommand]
    private void AddNewContact()
    {
        ListHandler.ContactAdd(new ContactModel
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            Phone = Phone,
            Street = Street,
            ZipCode = ZipCode,
            City = City,
        });

        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        Phone = string.Empty;
        Street = string.Empty;
        ZipCode = string.Empty;
        City = string.Empty;
    }
}
