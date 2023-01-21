
using CommunityToolkit.Mvvm.ComponentModel;
using System.Web;
using WPF_App.Mvvm.Models;

namespace WPF_App.Mvvm.VievModels;

public partial class ContactsViewModel : ObservableObject
{
	[ObservableProperty]
	private string pageName = "Contact Information";

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

	public ContactsViewModel(ContactModel selectedContact)
	{
		Firstname = selectedContact.FirstName;
		Lastname = selectedContact.LastName;
		Email = selectedContact.Email;
		Phone = selectedContact.Phone;
		Street = selectedContact.Street;
		ZipCode = selectedContact.ZipCode;
		City = selectedContact.City;
	}

	public ContactsViewModel()
	{

	}

}
