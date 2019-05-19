using System;
using System.Collections.Generic;
using LocalDatabase.Model;
using LocalDatabase.ViewModel;
using Xamarin.Forms;

namespace LocalDatabase.View
{
    public partial class UsersListPage : ContentPage
    {
        public void Handle_Appearing(object sender, System.EventArgs e)
        {
            try
            {
                var viewCell = (ViewCell)sender;
                //viewCell.View.TranslateTo(150, 0, 1000, Easing.SinIn);

            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
            }
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await App.Database.DeleteTableAsync<UserModel>(); // deletes table

            // UI ni ogohlantiradi ViewModel Orqali
            var binding = (UsersListPageViewModel)this.BindingContext;
            binding.InitUsers();
        }

        public UsersListPage()
        {
            InitializeComponent();
        }
    }
}
