
using System;
using WPF_App.Intefaces;

namespace WPF_App.Mvvm.Models;

public class ContactModel : IContact
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Adress => $"{Street} {ZipCode}, {City}";
    public string DisplayName => $"{FirstName}, {LastName}";
}
