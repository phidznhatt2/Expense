using System;
using System.Collections.Generic;
using System.Text;

namespace Expense.Models
{
    public class User
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
    }
}
