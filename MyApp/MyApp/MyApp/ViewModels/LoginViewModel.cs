using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MyApp.ViewModels.Base;
using MyApp.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace MyApp.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        public ICommand OnLoginCommand { get; set; }

        private string _userName;
        private string _errorMessage;
        private bool _hasErrors;
        private readonly INavigationService _navigationService;

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public bool HasErrors
        {
            get => _hasErrors;
            set => SetProperty(ref _hasErrors, value);
        }

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            HasErrors = false;
            ErrorMessage = string.Empty;
            OnLoginCommand = new DelegateCommand(
                async () => await LoginHandler()
            );
        }

        private async Task LoginHandler()
        {
            if (string.IsNullOrEmpty(UserName))
            {
                ErrorMessage = "User name is required";
                HasErrors = true;
            }
            else
            {
                ErrorMessage = string.Empty;
                HasErrors = false;
                await _navigationService.NavigateAsync(new Uri($"ItemsPage", UriKind.Relative), null, false);
            }

        }
    }
}