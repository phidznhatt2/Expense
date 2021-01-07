using Expense.Consts;
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
    public class ItemDetailViewModel : INotifyPropertyChanged {


        private ItemDetail _itemDetail;
        public ItemDetail itemDetail {
            get { return _itemDetail; }
            set {
                _itemDetail = value;
                OnPropertyChanged("ItemDetail");
            }
        }

        public ItemDetailViewModel() {
        }
        public ItemDetailViewModel(string type, int id) {
            Task.Run(async () => { await InitializeDataAsync(type, id); }).Wait();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task InitializeDataAsync(string type, int id) {
            var registersServices = new RegistersServices();
            var typeConst = new TypeMethod();
            var registerItem = new Register();
            //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(expenseItem));

            registerItem = await registersServices.GetRegisterById(type, id);
            itemDetail = registerItem.data;

            if (type == typeConst.Income) {
                itemDetail.typeSub = "Thu nhập";
            }
            if (type == typeConst.Cost) {
                itemDetail.typeSub = "Chi phí";
            }
            
        }
    }
}
