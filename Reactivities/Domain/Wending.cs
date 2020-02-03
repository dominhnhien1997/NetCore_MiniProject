using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Wending
    {
        public Guid Id { get; set; }
        public string Address { get; set; }

        public string MyGroom { get; set; }

        public string MyBride { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public string Status { get; set; }

        public bool? IsEnbale { get; set; }
    }
}
