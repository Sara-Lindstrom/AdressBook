
using System.Windows;
using WPF_App.Models;
using WPF_App.Services;

namespace WPF_App;

/// <summary>
/// Interaction logic for AddContact.xaml
/// </summary>
public partial class AddContact : Window
{
    private ListHandler listHandler;

    public AddContact()
    {
        InitializeComponent();
        listHandler = new ListHandler();
    }

    private void Btn_Add_Click(object sender, RoutedEventArgs e)
    {
        listHandler.ContactAdd(new Contact
        {
            FirstName = tb_FirstName.Text,
            LastName = tb_LastName.Text,
            Email = tb_Email.Text,
            Phone = tb_Phone.Text,
            Street = tb_Street.Text,
            ZipCode = tb_ZipCode.Text,
            City = tb_City.Text
        });

        (Application.Current.MainWindow as MainWindow).populateContacts();

        ClearForm();
    }

    private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    public void ClearForm()
    {
        tb_FirstName.Text = "";
        tb_LastName.Text = "";
        tb_Email.Text = "";
        tb_Phone.Text = "";
        tb_Street.Text = "";
        tb_ZipCode.Text = "";
        tb_City.Text = "";
    }
}
