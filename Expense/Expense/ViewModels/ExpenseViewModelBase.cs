using Expense.Models;
using Expense.NavigationServices;
using Expense.Views;
using Expense.Views.Form;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Expense.ViewModels
{
    public class ExpenseViewModelBase : INotifyPropertyChanged
    {

        private object _selectedItem;


        protected readonly INavigationService NavigationService;
        public List<MasterPageItem> MasterPageItems { get; set; }

        public object SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                if (_selectedItem != null)
                    NavigationService.NavigateToPage(_selectedItem as MasterPageItem);
                NotifyPropertyChanged("SelectedItem");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public ExpenseViewModelBase()
        {
            NavigationService = new NavigationService();
            MasterPageItems = new List<MasterPageItem>
            {
                new MasterPageItem
                {
                    Title = "Overview",
                    IconSource = "user.png",
                    TargetType = typeof (HomePage)
                },
                new MasterPageItem
                {
                    Title = "Transaction",
                    IconSource = "message.png",
                    TargetType = typeof (SignIn)
                },
                new MasterPageItem
                {
                    Title = "Budget",
                    IconSource = "category.png",
                    TargetType = typeof (SignUp)
                },
                new MasterPageItem
                {
                    Title = "Trends",
                    IconSource = "trend.png",
                    TargetType = typeof (SignIn)
                }
            };
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
