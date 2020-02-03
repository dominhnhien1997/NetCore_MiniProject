using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public DateTime Birthday { get; set; }
    }
}
