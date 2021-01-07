using System;
using System.Collections.Generic;
using Plugin.RestClient;
using System.Text;
using System.Threading.Tasks;
using Expense.Models;
using Expense.Consts;

namespace Expense.Services
{
    public class TypesServices
    {
        TypeMethod typeConst = new TypeMethod();
        UrlApi urlConst = new UrlApi();

        public async Task<TypesManagement> GetAllCates(string type)
        {
            RestClient<TypesManagement> restClient = new RestClient<TypesManagement>();

            if (type == typeConst.Cost)
            {
                return await restClient.GetAsync(urlConst.Cost);
            }
            else if (type == typeConst.Income)
            {
                return await restClient.GetAsync(urlConst.Income);
            }
            else return null;
        }

        public async Task<TypesManagement> GetCateById(string type, int id)
        {
            RestClient<TypesManagement> restClient = new RestClient<TypesManagement>();

            if (type == typeConst.Cost)
            {
                return await restClient.GetAsyncById(id, urlConst.Cost);
            }
            else if (type == typeConst.Income)
            {
                return await restClient.GetAsyncById(id, urlConst.Income);
            }
            else return null;
        }

        public async Task<bool> PostCate(string type, ItemCate data)
        {
            RestClient<ItemCate> restClient = new RestClient<ItemCate>();

            if (type == typeConst.Cost)
            {
                return await restClient.PostAsync(data, urlConst.Cost);
            }
            else if (type == typeConst.Income)
            {
                return await restClient.PostAsync(data, urlConst.Income);
            }
            else return false;

        }

        public async Task<bool> PutCate(string type, int id, ItemCate data)
        {
            RestClient<ItemCate> restClient = new RestClient<ItemCate>();

            if (type == typeConst.Cost)
            {
                return await restClient.PutAsync(id, data, urlConst.Cost);
            }
            else if (type == typeConst.Income)
            {
                return await restClient.PutAsync(id, data, urlConst.Income);
            }
            else return false;
        }

        public async Task<bool> DeleteCate(string type, int id)
        {
            RestClient<TypesManagement> restClient = new RestClient<TypesManagement>();

            if (type == typeConst.Cost)
            {
                var url = urlConst.Cost + "?idMakeMoney=" + id;
                return await restClient.DeleteAsync(url);
            }
            else if (type == typeConst.Income)
            {
                var url = urlConst.Income + "?idSpend=" + id;
                return await restClient.DeleteAsync(url);
            }
            else return false;
        }
    }
}
