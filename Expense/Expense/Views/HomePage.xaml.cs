using Expense.Models;
using Expense.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Expense.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : MasterDetailPage {
        HomeViewModel viewModel;
        public HomePage() {
            InitializeComponent();

            BindingContext = viewModel = new HomeViewModel();
        }

        private async void OnItemSelected(object sendOnItemSelecteder, SelectedItemChangedEventArgs args) {
            var item = args.SelectedItem as ItemDetail;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item.type, item.id)));

            // Manually deselect item.
            ((ListView)sendOnItemSelecteder).SelectedItem = null;

        }

        private async void AddItem_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new ItemEditPage());
        }

        protected override bool OnBackButtonPressed() {
            return true;
        }
    }
}