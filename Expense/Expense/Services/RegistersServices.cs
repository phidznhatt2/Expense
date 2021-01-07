using System;
using System.Collections.Generic;
using Plugin.RestClient;
using System.Text;
using System.Threading.Tasks;
using Expense.Models;
using Expense.Consts;

namespace Expense.Services
{
    public class RegistersServices
    {
        TypeMethod typeConst = new TypeMethod();
        UrlApi urlConst = new UrlApi();

        public async Task<Registers> GetAllRegisters(string id) 
        {
            var url = urlConst.RegisterAll + "?idUser=" + id;

            RestClient<Registers> restClient = new RestClient<Registers>();

            return await restClient.GetAsync(url);
        }

        public async Task<Register> GetRegisterById(string type, int id)
        {
            var url = urlConst.RegisterById + "?idService=" + id + "&type=" + type;

            RestClient<Register> restClient = new RestClient<Register>();

            return await restClient.GetRegisterAsyncById(url);
        }

        public async Task<bool> PostRegister(PostRegister data)
        {
            RestClient<PostRegister> restClient = new RestClient<PostRegister>();

            return await restClient.PostAsync(data, urlConst.Register);
        }

        public async Task<bool> PutRegister(PutRegister data)
        {
            RestClient<PutRegister> restClient = new RestClient<PutRegister>();

            return await restClient.PutAsync(data.id, data, urlConst.Register);
        }

        public async Task<bool> DeleteRegister(string type, int id)
        {
            var url = urlConst.Register + "?id=" + id + "&type=" + type;

            RestClient<Registers> restClient = new RestClient<Registers>();

            if (type == typeConst.Cost)
            {
                return await restClient.DeleteAsync(url);

            }
            else if (type == typeConst.Income)
            {
                return await restClient.DeleteAsync(url);
            }
            else return false;
        }
    }
}
