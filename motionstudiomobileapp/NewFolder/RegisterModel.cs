using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace motionstudiomobileapp.NewFolder
{
    class RegisterModel : INotifyPropertyChanged
    {
        public string webApiKey = "AIzaSyAeYpwc2KwTILNAGX4-y07bvZVVrjdx0F0";

        private INavigation _navigation;
        private string email;
        private string password;
        private Entry passwordEntry;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsPasswordHidden { get; set; } = true;

        public string PasswordToggleImage => IsPasswordHidden ? "showpass.png" : "hidepass.png";
        public Command ShowPasswordCommand { get; }

        public string Email
        {
            get => email; 
            set
            {
                email = value?.Trim();
                RaisePropertyChanged("Email");
            }
        }

        public string Password 
        { 
            get => password; 
            set 
            { 
                password = value?.Trim(); 
                RaisePropertyChanged("Password");
            } 
        
        }

        public Command RegisterUser { get; }

        private void RaisePropertyChanged(string v) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public RegisterModel(INavigation navigation)
        {
            this._navigation = navigation;
            RegisterUser = new Command(RegisterUserTappedAsync);
            ShowPasswordCommand = new Command(OnShowPassword);
            Email = "";
            Password = "";
        }

        private void OnShowPassword(object obj)
        {
            IsPasswordHidden = !IsPasswordHidden;
            RaisePropertyChanged(nameof(IsPasswordHidden));
            RaisePropertyChanged(nameof(PasswordToggleImage));
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }

        private async void RegisterUserTappedAsync(object obj)
          {
            var trimmedEmail = email.Trim();
            var trimmedPassword = password.Trim();

            if (string.IsNullOrEmpty(trimmedEmail))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Email cannot be empty.", "OK");
                return;
            }

            // Check if password is present
            if (string.IsNullOrEmpty(trimmedPassword))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Password cannot be empty.", "OK");
                return;
            }

            //for email validation

            if (!IsValidEmail(trimmedEmail))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Invalid email format.", "OK");
                return;
            }

            //for password
            if (trimmedPassword.Length != 10 || trimmedPassword.Any(char.IsDigit))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Password must be 10 characters long and contain only strings.", "OK");
                return;
            }

            try
            {

                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Email, Password);
                string token = auth.FirebaseToken;
                if (token != null) 
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "User Registered successfully", "OK");
                    await this._navigation.PopAsync();


                }
            }
            catch (Exception e) 
            {
                await App.Current.MainPage.DisplayAlert("Alert", e.Message, "OK");
                
            }
        }
    }
}
