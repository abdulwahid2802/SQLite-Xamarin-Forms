using System;
using System.Collections.Generic;
using LocalDatabase.Model;
using LocalDatabase.ViewModel;
using Xamarin.Forms;

namespace LocalDatabase.View
{
    public partial class UserAddPage : ContentPage
    {
        public UserAddPage()
        {
            InitializeComponent();
        }

        public UserAddPage(object bindingContext) : this()
        {
            BindingContext = bindingContext;
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            var user = new UserModel()
            {
                Name = "Toshmat"
            };

            var binding = BindingContext as UsersListPageViewModel;

            binding.Users.Add(user);

            await App.Database.SaveUserAsync(user);
            await Navigation.PopAsync();
        }
    }
}
