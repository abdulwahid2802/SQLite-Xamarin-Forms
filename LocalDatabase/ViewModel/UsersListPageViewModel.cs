using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using LocalDatabase.Model;
using Xamarin.Forms;

namespace LocalDatabase.ViewModel
{
    public class UsersListPageViewModel : ViewModelBase
    {
        private ObservableCollection<UserModel> _users;

        public UsersListPageViewModel()
        {
            InitUsers();
        }

        public async void InitUsers()
        {
            Users = new ObservableCollection<UserModel>(await App.Database.GetUsersAsync());
        }

        public ICommand AddCommand
        {
            get
            {
                return new Command
                (
                    execute: async () =>
                    {
                        var user = new UserModel()
                        {
                            Name = "New User",
                            Email = "New email"
                        };

                        Users.Add(user);
                        await App.Database.SaveUserAsync(user);
                    }
                );
            }
        }

        public ICommand DeleteAllCommand
        {
            get
            {
                return new Command
                (
                    execute: async () =>
                    {
                        Users.Clear();
                        await App.Database.DeleteTableAsync<UserModel>();
                    }
                );
            }
        }


        public ICommand DeleteUserCommand
        {
            get
            {
                return new Command<UserModel>
                (
                    execute: async (param) =>
                    {
                        Console.WriteLine("Delete Called");
                        var user = param as UserModel;
                        Users.Remove(user);
                        await App.Database.DeleteUserAsync(user);
                    }
                );
            }
        }


        public ObservableCollection<UserModel> Users
        {
            get
            {
                return _users;
            }

            private set
            {
                SetProperty(ref _users, value);
            }
        }
    }
}
