using Expense.Models;
using Expense.Services;
using Expense.Views.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Expense.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignIn : ContentPage {
        public SignIn() {
            InitializeComponent();
        }
        private async void SignIn_Clicked(object sender, EventArgs e) {
            UserInfo userLogin = new UserInfo();
            var usersServices = new UsersServices();
            var data = new { username = username.Text, password = password.Text};
            userLogin = await usersServices.LoginUserAsync(data);

            if(userLogin is null) {
                await DisplayAlert("Thông báo", "Tên đăng nhập hoặc mật khẩu không chính xác!", "ok");
            } else {
                await DisplayAlert("Thông báo", "Đăng nhập thành công", "ok");
                Application.Current.Properties["userId"] = userLogin.data.id;
                //Application.Current.Properties["accessToken"] = userLogin.data.accessToken;
                await SecureStorage.SetAsync("oauthtoken", userLogin.data.accessToken);
                await Navigation.PushAsync(new MasterDetail());
            }
        }

        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }
    }
}