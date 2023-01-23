using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPF_App.Mvvm.Models;
using WPF_App.Services;

namespace WPF_App.Mvvm.VievModels
{
    internal partial class EditContactViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "Edit Contact";

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
    }
}
