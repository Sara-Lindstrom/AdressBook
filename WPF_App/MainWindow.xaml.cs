
using System.CodeDom;
using System.Windows;
using System.Windows.Controls;
using WPF_App.Mvvm.Models;
using WPF_App.Services;

namespace WPF_App;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Btn_Remove_Click(object sender, RoutedEventArgs e)
    {        
        var removeButton = sender as Button;
        var item = (ContactModel)removeButton!.DataContext;

        //pop up confirmating
        string messageBoxText = $"Are you sure you Want to remove {item.DisplayName} from your contacts?";
        string caption = "Delete Warning";
        
        MessageBoxButton button = MessageBoxButton.YesNo;
        MessageBoxImage icon = MessageBoxImage.Warning;
        MessageBoxResult result;

        result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

        //removing contact if yes
        if (result == MessageBoxResult.Yes)
        {
            ListHandler.ContactRemove(item);
        }
    }
}
