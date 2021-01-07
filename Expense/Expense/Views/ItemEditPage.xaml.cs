using Expense.ViewModels;
using Expense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Expense.Services;
using Expense.Consts;

namespace Expense.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemEditPage : ContentPage {
        ItemEditViewModel viewModel;

        /*
        * flag = false (Create)
        * flag = true (Update)
        */
        bool flag = false;
        int id;

        List<string> ListCategoryPicker = new List<string>() { "Chi tiêu", "Thu nhập" };

        public ItemEditPage(ItemDetail itemRegister) {
            InitializeComponent();

            flag = true;
            id = itemRegister.id;

            BindingContext = viewModel = new ItemEditViewModel();

            OnInitUpdate(itemRegister);
        }

        public ItemEditPage() {
            InitializeComponent();

            flag = false;

            BindingContext = viewModel = new ItemEditViewModel();

            OnInit();
        }

        public void OnInit() {
            DtbPicker.ItemsSource = ListCategoryPicker;
            DtbPicker.SelectedIndex = 0;
        }

        public void OnInitUpdate(ItemDetail itemRegister) {
            DtbPicker.ItemsSource = ListCategoryPicker;
            DtbPicker.SelectedIndex = ListCategoryPicker.FindIndex(item => item == itemRegister.typeSub);

            Money.Text = itemRegister.money.ToString();
            datePicker.Date = itemRegister.dateCreate;
            Description.Text = itemRegister.description;

            ImageContent.Source = itemRegister.img;

            if (itemRegister.typeSub == "Thu nhập") {
                ContentPicker.SelectedIndex = viewModel.ListIncomesPicker.FindIndex(item => item == itemRegister.name);
            } else if (itemRegister.typeSub == "Chi tiêu") {
                ContentPicker.SelectedIndex = viewModel.ListCostsPicker.FindIndex(item => item == itemRegister.name);
            }
        }

        void OnDateSelected(object sender, DateChangedEventArgs args) {
            Recalculate();
        }

        void Recalculate() {

        }

        private void DtbPicker_SelectedIndexChanged(object sender, EventArgs e) {
            var index = DtbPicker.SelectedIndex;

            if (index == 0) {
                ContentPicker.ItemsSource = viewModel.ListCostsPicker;
                ContentPicker.SelectedIndex = 0;

                ImageContent.Source = viewModel.ListImageCosts[0];
            } else {
                ContentPicker.ItemsSource = viewModel.ListIncomesPicker;
                ContentPicker.SelectedIndex = 0;

                ImageContent.Source = viewModel.ListImageIncomes[0];
            }
        }

        private void ContentPicker_SelectedIndexChanged(object sender, EventArgs e) {
            var indexDtbSelected = DtbPicker.SelectedIndex;
            var index = ContentPicker.SelectedIndex;

            if (index != -1) {
                if (indexDtbSelected == 0) {
                    ImageContent.Source = viewModel.ListImageCosts[index];
                } else {
                    ImageContent.Source = viewModel.ListImageIncomes[index];
                }
            }
        }

        private async void CreateItem() {

            var typeConst = new TypeMethod();
            var urlConst = new UrlApi();
            var registersServices = new RegistersServices();

            if (!string.IsNullOrEmpty(Money.Text)) {
                var indexDtbSelected = DtbPicker.SelectedIndex;
                var indexItemSelected = ContentPicker.SelectedIndex;
                var status = false;

                double money = double.Parse(Money.Text);
                string description = string.IsNullOrEmpty(Description.Text) ? "" : Description.Text;
                string idUser = Application.Current.Properties["userId"].ToString();

                if (indexDtbSelected == 0) {
                    string type = typeConst.Cost;
                    int idService = viewModel.ListCostsId[indexItemSelected];

                    PostRegister ItemCost = new PostRegister(type, money, description, idUser, idService);

                    status = await registersServices.PostRegister(ItemCost);
                } else {
                    string type = typeConst.Income;
                    int idService = viewModel.ListIncomesId[indexItemSelected];

                    PostRegister ItemIncome = new PostRegister(type, money, description, idUser, idService);

                    status = await registersServices.PostRegister(ItemIncome);
                }

                if (status) {
                    await DisplayAlert("Thông báo", "Thêm thành công!", "ok");
                    await Navigation.PushAsync(new HomePage());
                } else {
                    await DisplayAlert("Thông báo", "Thêm không thành công. Vui lòng thử lại sau!", "ok");
                }
            } else {
                await DisplayAlert("Thông báo", "Vui lòng nhập đầy đủ thông tin!", "cancel");
                return;
            }
        }

        private async void UpdateItem() {

            var typeConst = new TypeMethod();
            var urlConst = new UrlApi();
            var registersServices = new RegistersServices();

            if (!string.IsNullOrEmpty(Money.Text)) {
                var indexDtbSelected = DtbPicker.SelectedIndex;
                var indexItemSelected = ContentPicker.SelectedIndex;
                var status = false;

                double money = double.Parse(Money.Text);
                string description = string.IsNullOrEmpty(Description.Text) ? "" : Description.Text;
                string idUser = Application.Current.Properties["userId"].ToString();

                if (indexDtbSelected == 0) {
                    string type = typeConst.Cost;
                    int idService = viewModel.ListCostsId[indexItemSelected];

                    PutRegister ItemCost = new PutRegister(id, type, money, description, idService);

                    status = await registersServices.PutRegister(ItemCost);
                } else {
                    string type = typeConst.Income;
                    int idService = viewModel.ListIncomesId[indexItemSelected];

                    PutRegister ItemIncome = new PutRegister(id, type, money, description, idService);

                    status = await registersServices.PutRegister(ItemIncome);
                }

                if (status) {
                    await DisplayAlert("Thông báo", "Cập nhật thành công!", "ok");
                    await Navigation.PushAsync(new HomePage());
                } else {
                    await DisplayAlert("Thông báo", "Cập nhật không thành công. Vui lòng thử lại sau!", "ok");
                }
            } else {
                await DisplayAlert("Thông báo", "Vui lòng nhập đầy đủ thông tin!", "cancel");
                return;
            }
        }

        private void Action_Clicked(object sender, EventArgs e) {

            if (flag) {
                UpdateItem();
            } else {
                CreateItem();
            }

        }
    }

    public class CustomEntry : Entry {

    }

    public class CustomPicker : Picker {

    }
}