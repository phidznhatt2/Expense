using Expense.Models;
using Expense.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Expense.ViewModels
{
    public class ItemEditViewModel : INotifyPropertyChanged {

        TypesManagement CostManagement = new TypesManagement();
        TypesManagement IncomeManagement = new TypesManagement();

        public List<string> ListCostsPicker = new List<string>();
        public List<int> ListCostsId = new List<int>();
        public List<string> ListImageCosts = new List<string>();

        public List<string> ListIncomesPicker = new List<string>();
        public List<int> ListIncomesId = new List<int>();
        public List<string> ListImageIncomes = new List<string>();

        public ItemEditViewModel() {
            Task.Run(async () => { await InitializeDataAsync(); }).Wait();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task InitializeDataAsync() {
            var TypesServices = new TypesServices();
            CostManagement = await TypesServices.GetAllCates("chiphi");
            IncomeManagement = await TypesServices.GetAllCates("thunhap");

            foreach (ItemCate item in CostManagement.data.items) {
                ListCostsPicker.Add(item.name);
                ListCostsId.Add(item.id);
                ListImageCosts.Add(item.img);
            }

            foreach (ItemCate item in IncomeManagement.data.items) {
                ListIncomesPicker.Add(item.name);
                ListIncomesId.Add(item.id);
                ListImageIncomes.Add(item.img);
            }
        }
    }
}
