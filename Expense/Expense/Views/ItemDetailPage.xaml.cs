using Expense.Models;
using Expense.Services;
using Expense.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Expense.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();
        }

        public async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            var registersServices = new RegistersServices();
            bool answer = await DisplayAlert("Thông báo", "Bạn có muốn xóa dữ liệu?", "Có", "Không");
            if (answer)
            {
                ItemDetail item = viewModel.itemDetail;
                bool statusDel = await registersServices.DeleteRegister(item.type, item.id);

                if (statusDel)
                {
                    await DisplayAlert("Thông báo", "Xóa thành công!", "ok");
                    await Navigation.PushAsync(new HomePage());
                }
                else
                {
                    await DisplayAlert("Thông báo", "Xóa không thành công. Vui lòng thử lại sau!", "ok");
                }
            }

        }

        private async void EditItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemEditPage(viewModel.itemDetail));
        }
    }
}