using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using Newtonsoft.Json;

namespace SimpleLoginApp.ViewModels
{
    public class UsersViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> Users { get; set; } = new ObservableCollection<string>();

        public UsersViewModel()
        {
            LoadUsersFromApi();
        }

        private async void LoadUsersFromApi()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var json = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");
                    var users = JsonConvert.DeserializeObject<List<UserModel>>(json);

                    Users.Clear();
                    foreach (var user in users)
                        Users.Add(user.Name);
                }
            }
            catch
            {
                Users.Add("⛔ خطا در دریافت کاربران");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
