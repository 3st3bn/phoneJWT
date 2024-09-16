
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using phoneJWT.Models;
using System.Text;
using System.Text.Json;
using phoneJWT.Services.Interfaces;

namespace phoneJWT.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly ILoginService _loginService;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string token;

        public LoginViewModel()
        {
            _loginService = Startup.GetService<ILoginService>();
            LoginCommand = new AsyncRelayCommand(LoginAsync);
        }

        public IAsyncRelayCommand LoginCommand { get; }

        private async Task LoginAsync()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Username and Password are required.", "OK");
                return;
            }

            var resultToken = await _loginService.LoginAsync(Name, Password);

            if (resultToken != null)
            {
                Token = resultToken;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Invalid username or password.", "OK");
            }
        }
    }

}
