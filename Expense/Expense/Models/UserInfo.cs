using System;
using System.Collections.Generic;
using System.Text;

namespace Expense.Models {
    public class DataUser
    {
        public string accessToken { get; set; }
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public object phone { get; set; }
        public double totalSpend { get; set; }
        public double totalMakeMoney { get; set; }
        public double limitMoney { get; set; }
        public double accountBalance { get; set; }
    }

    public class UserInfo
    {
        public bool isSuccessed { get; set; }
        public string message { get; set; }
        public DataUser data { get; set; }
    }
}
