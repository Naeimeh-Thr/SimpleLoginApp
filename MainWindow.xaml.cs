using System.Windows;
using SimpleLoginApp.ViewModels;
using SimpleLoginApp.Views;

namespace SimpleLoginApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var loginView = new LoginView();
            var loginVM = new LoginViewModel();
            loginView.DataContext = loginVM;

            loginVM.LoginSucceeded += OnLoginSuccess;

            MainContent.Content = loginView;
        }

        private void OnLoginSuccess()
        {
            var usersView = new UsersView();
            usersView.LogoutRequested += OnLogout; // گوش به سیگنال خروج
            MainContent.Content = usersView;
        }

        private void OnLogout()
        {
            // برگرد به لاگین
            var loginView = new LoginView();
            var loginVM = new LoginViewModel();
            loginView.DataContext = loginVM;

            loginVM.LoginSucceeded += OnLoginSuccess;

            MainContent.Content = loginView;
        }

    }
}
