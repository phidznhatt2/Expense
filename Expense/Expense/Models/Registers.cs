using System;
using System.Collections.Generic;
using System.Text;

namespace Expense.Models
{
    public class ItemDetail
    {
        public int id { get; set; }
        public string name { get; set; }
        public string img { get; set; }
        public double money { get; set; }
        public string type { get; set; }
        public string typeSub { get; set; }
        public string description { get; set; }
        public DateTime dateCreate { get; set; }
        public string dateCreateToString { get; set; }
    }

    public class ItemRegister
    {
        public DateTime dateCreate { get; set; }
        public List<ItemDetail> data { get; set; }
        public int HeightList { get; set; }
        public double CostSum { get; set; }
        public double IncomeSum { get; set; }

        public void AddProperty(int HeightList, double CostSum, double IncomeSum)
        {
            this.HeightList = HeightList;
            this.CostSum = CostSum;
            this.IncomeSum = IncomeSum;
        }
    }

    public class DataRegister
    {
        public List<ItemRegister> items { get; set; }
        public int totalRecords { get; set; }
    }

    public class Registers
    {
        public bool isSuccessed { get; set; }
        public string message { get; set; }
        public DataRegister data { get; set; }
    }

    public class Register
    {
        public bool isSuccessed { get; set; }
        public string message { get; set; }
        public ItemDetail data { get; set; }
    }

    public class PostRegister
    {
        public string type { get; set; }
        public double money { get; set; }
        public string description { get; set; }
        public string idUser { get; set; }
        public int idService { get; set; }

        public PostRegister() { }

        public PostRegister(string type, double money, string description, string idUser, int idService){
            this.type = type;
            this.money = money;
            this.description = description;
            this.idUser = idUser;
            this.idService = idService;
        }
    }

    public class PutRegister
    {
        public int id { get; set; }
        public string type { get; set; }
        public double money { get; set; }
        public string description { get; set; }
        public int idService { get; set; }

        public PutRegister() { }

        public PutRegister(int id, string type, double money, string description, int idService)
        {
            this.id = id;
            this.type = type;
            this.money = money;
            this.description = description;
            this.idService = idService;
        }
    }
}
