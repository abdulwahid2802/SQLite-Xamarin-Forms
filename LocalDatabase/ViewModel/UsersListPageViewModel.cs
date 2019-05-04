using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using LocalDatabase.Model;

namespace LocalDatabase.ViewModel
{
    public class UsersListPageViewModel : ViewModelBase
    {
        private List<UserModel> _users;

        public UsersListPageViewModel()
        {
            InitUsers();
        }

        private async void InitUsers()
        {
            Users = await App.Database.GetUsersAsync();
        }

        public List<UserModel> Users
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
