using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class TestHoliday
    {

        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public string Address1 { get; set; }
        public string DisplayName { get; set; }

        public int Age { get; set; }
    }
}
