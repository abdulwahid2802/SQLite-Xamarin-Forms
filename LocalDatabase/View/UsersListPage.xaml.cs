using System;
using System.Collections.Generic;
using LocalDatabase.Model;
using LocalDatabase.ViewModel;
using Xamarin.Forms;

namespace LocalDatabase.View
{
    public partial class UsersListPage : ContentPage
    {

        void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new UserAddPage(this.BindingContext));
        }

        public UsersListPage()
        {
            InitializeComponent();
        }
    }
}
