using Expense.Consts;
using Expense.Models;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Expense.Services
{
    public class UsersServices
    {
        UrlApi urlConst = new UrlApi();

        public async Task<User> GetUserAsync(string id) 
        {
            RestClient<User> restClient = new RestClient<User>();

            var url = urlConst.User + "?id=" + id;

            return await restClient.GetAsync(url);
        }

        public async Task<UserInfo> LoginUserAsync(object data) 
        {
            RestClient<UserInfo> restClient = new RestClient<UserInfo>();

            return await restClient.PostSignInAsync(data, urlConst.UserLogin);
        }

        public async Task<bool> RegisterUserAsync(object data)
        {
            RestClient<bool> restClient = new RestClient<bool>();

            return await restClient.PostSignUpAsync(data, urlConst.UserRegister);
        }
    }
}
