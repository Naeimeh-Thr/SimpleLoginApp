using System;
using System.Windows;
using System.Windows.Controls;
using SimpleLoginApp.ViewModels;

namespace SimpleLoginApp.Views
{
    public partial class UsersView : UserControl
    {
        public event Action LogoutRequested;

        public UsersView()
        {
            InitializeComponent();
            this.DataContext = new UsersViewModel();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LogoutRequested?.Invoke(); 
        }
    }
}
