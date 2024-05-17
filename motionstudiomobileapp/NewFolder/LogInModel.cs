using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motionstudiomobileapp.NewFolder
{
    internal class LogInModel : INotifyPropertyChanged
    {
        public string webApiKey = "AIzaSyAeYpwc2KwTILNAGX4-y07bvZVVrjdx0F0";

        private INavigation _navigation;
        private string userName;
        private string userPassword;
        private Entry passwordEntry;


        public event PropertyChangedEventHandler? PropertyChanged;

        public Command RegisterBtn { get; }
        public Command LoginBtn { get; }

        public bool IsPasswordHidden { get; set; } = true;

        public string PasswordToggleImage => IsPasswordHidden ? "showpass.png" : "hidepass.png";
        public Command ShowPasswordCommand { get; }

        public string UserName
        {
            get => userName;
            set
            {
                userName = value?.Trim();
                RaisePropertyChanged("UserName");
            }
        }

        public string UserPassword
        {
            get => userPassword;
            set
            {

                userPassword = value?.Trim();
                RaisePropertyChanged("UserPassword");
            }
        }



        public LogInModel(INavigation navigation)
        {
            this._navigation = navigation;
            RegisterBtn = new Command(RegisterBtnTappedAsync);
            LoginBtn = new Command(LoginBtnTappedAsync);
            ShowPasswordCommand = new Command(OnShowPassword);
        }

        private void OnShowPassword(object obj)
        {
            IsPasswordHidden = !IsPasswordHidden;
            RaisePropertyChanged(nameof(IsPasswordHidden));
            RaisePropertyChanged(nameof(PasswordToggleImage));
        }


        private async void LoginBtnTappedAsync(object obj)
        {
            var trimmedEmail = UserName.Trim();
            var trimmedPassword = UserPassword.Trim();

            if (!IsValidEmail(trimmedEmail) || !trimmedEmail.EndsWith(".com"))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Invalid email format.", "OK");
                return;
            }

            if (string.IsNullOrEmpty(trimmedEmail) || string.IsNullOrEmpty(trimmedPassword))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Please enter both email and password.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(trimmedPassword))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Please enter a password.", "OK");
                return;
            }



            if (trimmedPassword.Length < 10 ) 
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Password must be at least 10 characters long.", "OK");
                return;
            } 

            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserName, UserPassword);
                var content = await auth.GetFreshAuthAsync();
                var serializedContent = JsonConvert.SerializeObject(content);
                Preferences.Set("FreshFirebaseToken", serializedContent);
                await this._navigation.PushAsync(new Dashboard());
            }
            catch (FirebaseAuthException ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
               
            }

        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private async void RegisterBtnTappedAsync(object obj)
        {
            await this._navigation.PushAsync(new Register());
        }

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }


       
        
    }
}