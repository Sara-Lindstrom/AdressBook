
namespace Console_App.Interfaces;

internal interface IContact
{
    Guid Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    string Phone { get; set; }
    string Street { get; set; }
    string ZipCode { get; set; }
    string City { get; set; }
}
