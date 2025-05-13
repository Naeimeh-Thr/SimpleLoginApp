using System.Windows;
using System.Windows.Controls;
using SimpleLoginApp.ViewModels;

namespace SimpleLoginApp.Views
{
    public partial class LoginView : UserControl
    {
        private LoginViewModel _viewModel;

        public LoginView()
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                _viewModel = (LoginViewModel)this.DataContext;
            };
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string password = passwordBox.Password;
            _ = _viewModel.Login(password);
        }
    }
}
