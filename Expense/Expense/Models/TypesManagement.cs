using System;
using System.Collections.Generic;
using System.Text;

namespace Expense.Models
{
    public class ItemCate
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string img { get; set; }
        public bool status { get; set; }

        public ItemCate() {}

        public ItemCate(int id, string name, string description, string img, bool status)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.img = img;
            this.status = status;
        }


    }

    public class DataType
    {
        public List<ItemCate> items { get; set; }
        public int totalRecords { get; set; }
    }

    public class TypesManagement
    {
        public bool isSuccessed { get; set; }
        public string message { get; set; }
        public DataType data { get; set; }
    }

    public class TypeManagement
    {
        public bool isSuccessed { get; set; }
        public string message { get; set; }
        public ItemCate data { get; set; }
    }
}
