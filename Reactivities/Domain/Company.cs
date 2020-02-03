using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name_Company { get; set; }

        public string Address { get; set; }
        public int TotalEmployee { get; set; }

        public string Tax { get; set; }

        public string BankSign { get; set; }
        public string NameCeo { get; set; } // day la nguoi dai dien phat luat
    }
}
