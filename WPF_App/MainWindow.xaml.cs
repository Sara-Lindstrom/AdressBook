
using System.Windows;
using WPF_App.Services;

namespace WPF_App;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private ListHandler listHandler;

    public MainWindow()
    {
        InitializeComponent();
        listHandler = new ListHandler();
        populateContacts();
    }

    public void populateContacts ()
    {
        Lv_Contacts.ItemsSource = listHandler.GetAllContacts();
    }

    private void Btn_Add_Click(object sender, RoutedEventArgs e)
    {
        AddContact addContactWindow = new AddContact();
        addContactWindow.ShowDialog();
    }

    private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Btn_Edit_Click(object sender, RoutedEventArgs e)
    {

    }
}
