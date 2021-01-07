using Expense.Models;
using Expense.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Expense.Views.Form
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage
    {
        User users = new User();
        UsersServices usersServices = new UsersServices();

        public SignUp()
        {
            InitializeComponent();
            firstNameEntry.ReturnCommand = new Command(() => userNameEntry.Focus());
            lastNameEntry.ReturnCommand = new Command(() => userNameEntry.Focus());
            userNameEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
            passwordEntry.ReturnCommand = new Command(() => confirmpasswordEntry.Focus());
            confirmpasswordEntry.ReturnCommand = new Command(() => phoneEntry.Focus());
        }

        private async void SignupValidation_ButtonClicked(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(userNameEntry.Text)) || (string.IsNullOrWhiteSpace(firstNameEntry.Text)) || (string.IsNullOrWhiteSpace(lastNameEntry.Text))  ||
                (string.IsNullOrWhiteSpace(passwordEntry.Text)) || (string.IsNullOrWhiteSpace(phoneEntry.Text)) ||
                (string.IsNullOrEmpty(userNameEntry.Text)) || (string.IsNullOrEmpty(firstNameEntry.Text)) || (string.IsNullOrEmpty(lastNameEntry.Text)) ||
                (string.IsNullOrEmpty(passwordEntry.Text)) || (string.IsNullOrEmpty(phoneEntry.Text)))

            {
                await DisplayAlert("Enter Data", "Enter Valid Data", "OK");
            }
            else if (!string.Equals(passwordEntry.Text, confirmpasswordEntry.Text))
            {
                warningLabel.Text = "Please enter the same value again.";
                passwordEntry.Text = string.Empty;
                confirmpasswordEntry.Text = string.Empty;
                warningLabel.TextColor = Color.IndianRed;
                warningLabel.IsVisible = true;
            }
            else if (phoneEntry.Text.Length < 10)
            {
                phoneEntry.Text = string.Empty;
                phoneWarLabel.Text = "Enter 10 digit Number";
                phoneWarLabel.TextColor = Color.IndianRed;
                phoneWarLabel.IsVisible = true;
            }
            else
            {
                users.firstName = firstNameEntry.Text;
                users.lastName = lastNameEntry.Text;
                users.userName = userNameEntry.Text;
                users.password = passwordEntry.Text;
                users.password = confirmpasswordEntry.Text;
                users.phone = phoneEntry.Text.ToString();
                try
                {
                    var returnvalue = await usersServices.RegisterUserAsync(users);
                    if (returnvalue)
                    {
                        await DisplayAlert("User Add", "Sucessfully Added", "OK");

                        await Navigation.PushAsync(new SignIn());
                    }
                    else
                    {
                        await DisplayAlert("User Add", "There was a problem connecting \b to the server. Please try again.", "Try again");
                        warningLabel.IsVisible = false;
                        firstNameEntry.Text = string.Empty;
                        lastNameEntry.Text = string.Empty;
                        userNameEntry.Text = string.Empty;
                        passwordEntry.Text = string.Empty;
                        confirmpasswordEntry.Text = string.Empty;
                        phoneEntry.Text = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            //users.name = fullNameEntry.Text;
            //users.userName = userNameEntry.Text;
            //users.password = passwordEntry.Text;
            //users.phone = phoneEntry.Text.ToString();
        }

        private async void login_ClickedEvent(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignIn());
        }
    }
}