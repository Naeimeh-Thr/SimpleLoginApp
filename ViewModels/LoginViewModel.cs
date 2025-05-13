using System;
using System.ComponentModel;

namespace SimpleLoginApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _loginMessage;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string LoginMessage
        {
            get => _loginMessage;
            set
            {
                _loginMessage = value;
                OnPropertyChanged(nameof(LoginMessage));
            }
        }

        public event Action LoginSucceeded;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public bool Login(string password)
        {
            if (Username == "admin" && password == "1234")
            {
                LoginMessage = "ورود موفق";
                LoginSucceeded?.Invoke();  
                return true;
            }
            else
            {
                LoginMessage = "نام کاربری یا رمز عبور اشتباه است";
                return false;
            }
        }
    }
}
