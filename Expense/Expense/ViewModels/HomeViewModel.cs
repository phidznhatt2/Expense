using Expense.Consts;
using Expense.Models;
using Expense.Services;
using Expense.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Expense.ViewModels {
    public class HomeViewModel : INotifyPropertyChanged {

        private User _user;
        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged("User");
            }
        }
        private Registers _registersList;
        public Registers RegistersList{
            get { return _registersList; }
            set {
                _registersList = value;
                OnPropertyChanged("RegistersList");
            }
        }
        public HomeViewModel() {
            Task.Run(async () => { await InitializeDataAsync(); }).Wait();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task InitializeDataAsync() {
            var typeConst = new TypeMethod();
            var registersServices = new RegistersServices();
            var usersServices = new UsersServices();
            int HeightList = 0;
            double Cost = 0;
            double Income = 0;

            var idUser = Application.Current.Properties["userId"].ToString();
            User = await usersServices.GetUserAsync(idUser);
            RegistersList = await registersServices.GetAllRegisters(idUser);

            foreach (ItemRegister itemRegister in RegistersList.data.items) {
                HeightList = (itemRegister.data.Count * 40) + (10 * itemRegister.data.Count) + 30;
                //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(itemList));
                foreach (ItemDetail itemDetail in itemRegister.data) {
                    if(itemDetail.type == typeConst.Cost) {
                        Cost += itemDetail.money;
                    }

                    if(itemDetail.type == typeConst.Income) {
                        Income += itemDetail.money;
                    }
                }

                itemRegister.AddProperty(HeightList, Cost, Income);

                HeightList = 0; Cost = 0; Income = 0;
            }
        }
    }
}
